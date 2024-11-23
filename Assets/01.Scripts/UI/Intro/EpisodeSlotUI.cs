using UnityEngine;
using UnityEngine.UI;

public class EpisodeSlotUI : MonoBehaviourUI
{
    [SerializeField] GameObject dimedObject = null;
    [SerializeField] Image thumbnailImage = null;
    [SerializeField] Text titleText = null;
    
    private EpisodeDataSO currentEpisodeData = null;

    public void Initialize(EpisodeDataSO episodeData)
    {
        currentEpisodeData = episodeData;
        RefreshUI();
    }

    public void SetEnable(bool enable)
    {
        dimedObject.SetActive(!enable);
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
        
        GameManager.Instance.LoadSceneWithFade(currentEpisodeData.sceneType, onFinish: scene => {
            SoundManager.Instance.PlaySoundBGM();
        });
    }
}
