using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EpisodeSlotUI : MonoBehaviourUI
{
    [SerializeField] GameObject[] dimedObject = null;
    [SerializeField] Image thumbnailImage = null;
    public Text title = null;
    
    private EpisodeDataSO currentEpisodeData = null;
    
    public bool IsEnable { get; private set; }

    public void Initialize(EpisodeDataSO episodeData)
    {
        currentEpisodeData = episodeData;
        RefreshUI();
    }

    public void SetEnable(bool enable)
    {
        IsEnable = enable;
        foreach (var obj in dimedObject)
        {
            obj.SetActive(enable);
        }
    }

    private void RefreshUI()
    {
        thumbnailImage.sprite = currentEpisodeData.episodeThumbnail;
        title.text = currentEpisodeData.episodeName;
    }

    public void OnTouchStartEpisode()
    {
        if(currentEpisodeData == null)
            return;
        
        GameManager.Instance.LoadSceneWithFade(currentEpisodeData.sceneType, onFinish: scene => {
            SoundManager.Instance.PlaySoundBGM();
        });
    }
}
