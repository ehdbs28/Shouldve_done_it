using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SituationScene : BaseScene
{
    [SerializeField] EpisodeSlotGroupUI episodeSlotGroupUI = null;
     
    private SituationDataSO currentSituationData = null;

    public void StartSituation(SituationDataSO situationData)
    {
        currentSituationData = situationData;

        Cutscene cutscene = Instantiate(currentSituationData.cutscenePrefab);
        cutscene.Play(OnFinishCutscene);
    }

    private void OnFinishCutscene(Cutscene cutscene)
    {
        Debug.Log("--->OnFinishCutscene");
        episodeSlotGroupUI.Initialize(currentSituationData.episodeDatas);

        Destroy(cutscene.gameObject);
    }
}
