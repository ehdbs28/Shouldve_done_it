using UnityEngine;
using UnityEngine.UI;

public class EpisodeSlotUI : MonoBehaviourUI
{
    [SerializeField] EpisodeDataSO currentEpisodeData = null;

    [Space(15f)]
    [SerializeField] Image thumbnailImage = null;
    [SerializeField] Text titleText = null;

    public override void Show()
    {
        base.Show();
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
