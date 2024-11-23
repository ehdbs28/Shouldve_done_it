using UnityEngine;
using UnityEngine.UI;

public class EpisodeSlotUI : MonoBehaviourUI
{
    [SerializeField] Image thumbnailImage = null;
    [SerializeField] Text titleText = null;
    
    private EpisodeDataSO currentEpisodeData = null;

    public void Initialize(EpisodeDataSO episodeData)
    {
        currentEpisodeData = episodeData;
        RefreshUI();
    }

    private void RefreshUI()
    {
        thumbnailImage.sprite = currentEpisodeData.episodeThumbnail;
        titleText.text = currentEpisodeData.episodeName;
    }

    public void OnTouchStartEpisode()
    {
        if(currentEpisodeData == null)
            return;
        
        GameManager.Instance.LoadSceneWithFade(currentEpisodeData.sceneType);
    }
}
