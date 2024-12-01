using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EpisodeScene : BaseScene
{
    [SerializeField] EpisodeDataSO episodeData = null;
    [SerializeField, TextArea] private string _title;

    [SerializeField] private TitlePanel _titlePanelPrefab;
    private TitlePanel _titlePanel;

    [SerializeField] private QuotesPanel _quotesPanelPrefab;

    public override void OnPreLoadScene(Scenes next, Scenes prev)
    {
        base.OnPreLoadScene(next, prev);
        
        if (_titlePanel == null)
        {
            _titlePanel = Instantiate(_titlePanelPrefab, GameManager.Instance.uiCanvas.transform);
        }
        _titlePanel.Show(new GetLocalizeString(_title), next != prev, OnEpisodeStart);
    }

    protected virtual void OnEpisodeStart()
    {
    }

    public virtual void SetResult(string text, string author, bool success)
    {
        StartCoroutine(ResultRoutine(success ? Scenes.Situation : GameManager.Instance.CurrentSceneType, text, author));
    }

    private IEnumerator ResultRoutine(Scenes sceneType, string text = null, string author = null)
    {
        if (text != null && author != null)
        {
            var panel = Instantiate(_quotesPanelPrefab, GameManager.Instance.uiCanvas.transform);
            panel.Show(text, author);
            
            yield return new WaitForSeconds(5f);

            GameManager.Instance.LoadSceneWithFade(sceneType, scene => {
                panel.Close(true);

                if(sceneType == Scenes.Situation)
                    HandleSuccess(scene as SituationScene);
            });

            yield break;
        }
        
        yield return new WaitForSeconds(5f);
        
        GameManager.Instance.LoadSceneWithFade(sceneType, scene =>
            {
                if(sceneType == Scenes.Situation)
                    HandleSuccess(scene as SituationScene);
            });
    }
    
    private void HandleSuccess(SituationScene scene)
    {
        DataManager.UserData.ProgressData.CurrentEpisodeIndex = episodeData.episodeIndex + 1;
        scene.StartSituation(DataManager.UserData.ProgressData.CurrentSituationData);
        SoundManager.Instance.StopBGM();
    }
}
