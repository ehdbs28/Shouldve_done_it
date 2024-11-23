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
        _titlePanel.Show(_title, next != prev, OnEpisodeStart);
    }

    protected virtual void OnEpisodeStart()
    {
        
    }

    public virtual void SetResult(string text, string author, bool success)
    {
        StartCoroutine(ResultRoutine(success ? Scenes.Situation : Scenes.EpisodeCafe, text, author));
    }

    private IEnumerator ResultRoutine(Scenes sceneType, string text, string author)
    {
        var panel = Instantiate(_quotesPanelPrefab, GameManager.Instance.uiCanvas.transform);
        panel.Show(text, author);

        yield return new WaitForSeconds(5f);

        GameManager.Instance.LoadSceneWithFade(sceneType, scene =>
        {
            panel.Close(true);
        });
    }
    
}
