using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

        sceneUI.SetActive(false);
        backgroundImage.sprite = situationData.situationThumbnail;

        Cutscene cutscene = Instantiate(currentSituationData.cutscenePrefab);
        cutscene.Play(OnFinishCutscene);
    }

    private void OnFinishCutscene(Cutscene cutscene)
    {
        Debug.Log("--->OnFinishCutscene");
        sceneUI.SetActive(true);
        episodeSlotGroupUI.Initialize(currentSituationData.episodeDatas);

        Destroy(cutscene.gameObject);
    }
}
