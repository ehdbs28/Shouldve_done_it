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

        int currentEpisodeIndex = DataManager.UserData.ProgressData.CurrentEpisodeIndex;
        if(currentEpisodeIndex == 0 || currentEpisodeIndex >= currentSituationData.episodeDatas.Count)
        {
            Cutscene cutscene = Instantiate(currentSituationData.cutscenePrefabs[currentEpisodeIndex != 0]);
            cutscene.Play(OnFinishCutscene);
            return;
        }

        SetSituationUI();
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
