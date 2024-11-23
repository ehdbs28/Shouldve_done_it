using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SituationSlotUI : MonoBehaviourUI
{
    [SerializeField] SituationDataSO currentSituationData = null;
    [SerializeField] float displayDelay = 0f;

    [Space(15f)]
    [SerializeField] Image thumbnailImage = null;
    [SerializeField] Text titleText = null;

    private CanvasGroup canvasGroup = null;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        Show();
    }

    public override void Show()
    {
        base.Show();
        RefreshUI();
        
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1f, 0.75f).SetDelay(displayDelay);
    }

    private void RefreshUI()
    {
        if(currentSituationData == null)
            return;

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
