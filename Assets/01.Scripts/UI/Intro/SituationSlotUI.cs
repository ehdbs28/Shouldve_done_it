using UnityEngine;
using UnityEngine.UI;

public class SituationSlotUI : MonoBehaviourUI
{
    [SerializeField] SituationDataSO currentSituationData = null;

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
        thumbnailImage.sprite = currentSituationData.situationThumbnail;
        titleText.text = currentSituationData.situationName;

        if(DataManager.UserData.ProgressData.ClearedSituationList.Contains(currentSituationData.situationName))
            Debug.Log("->Set Dimed");
    }

    public void OnTouchStartSituation()
    {
        if(currentSituationData == null)
            return;

        if (DataManager.UserData.ProgressData.ClearedSituationList.Contains(currentSituationData.situationName))
            return;

        // Set Episode
        // Show Episode Group UI
        GameManager.Instance.LoadSceneWithFade<SituationScene>(Scenes.Situation, scene => {
            scene.StartSituation(currentSituationData);
        });
    }
}
