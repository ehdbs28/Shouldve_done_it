using UnityEngine;
using UnityEngine.Events;

public class EpisodeScene : BaseScene
{
    [SerializeField] EpisodeDataSO episodeData = null;
    [SerializeField, TextArea] private string _title;

    [SerializeField] private TitlePanel _titlePanelPrefab;
    private TitlePanel _titlePanel;

    protected override void OnSceneInitialize()
    {
        base.OnSceneInitialize();

        if (_titlePanel == null)
        {
            _titlePanel = Instantiate(_titlePanelPrefab, GameManager.Instance.uiCanvas.transform);
        }
        _titlePanelPrefab.Show(_title, OnEpisodeStart);
    }

    protected virtual void OnEpisodeStart()
    {
        
    }

    protected virtual void Fail(string text, string author)
    {
        
    }
}
