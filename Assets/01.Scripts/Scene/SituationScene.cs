using UnityEngine;
using UnityEngine.UI;

public class SituationScene : BaseScene
{
    [SerializeField] GameObject sceneUI = null;
    [SerializeField] Image backgroundImage = null;
    [SerializeField] EpisodeSlotGroupUI episodeSlotGroupUI = null;
     
    private SituationDataSO currentSituationData = null;

    public void StartSituation(SituationDataSO situationData)
    {
        currentSituationData = situationData;
        DataManager.UserData.ProgressData.CurrentSituationData = currentSituationData;

        sceneUI.SetActive(false);
        backgroundImage.sprite = situationData.situationThumbnail;

        if(DataManager.UserData.ProgressData.CurrentEpisodeIndex != 0)
        {
            SetSituationUI();
            return;
        }

        Cutscene cutscene = Instantiate(currentSituationData.cutscenePrefab);
        cutscene.Play(OnFinishCutscene);
    }

    private void OnFinishCutscene(Cutscene cutscene)
    {
        Debug.Log("--->OnFinishCutscene");

        SetSituationUI();
        Destroy(cutscene.gameObject);
    }

    private void SetSituationUI()
    {
        sceneUI.SetActive(true);
        episodeSlotGroupUI.Initialize(currentSituationData.episodeDatas);
    }
}
