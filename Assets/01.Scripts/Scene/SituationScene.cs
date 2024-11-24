using System.Collections;
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
        episodeSlotGroupUI.gameObject.SetActive(false);
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

        int currentEpisodeIndex = DataManager.UserData.ProgressData.CurrentEpisodeIndex;
        if(currentEpisodeIndex >= currentSituationData.episodeDatas.Count)
        {
            DataManager.UserData.ProgressData.CurrentEpisodeIndex = 0;
            DataManager.UserData.ProgressData.ClearedSituationList.Add(currentSituationData.situationName);
            GameManager.Instance.LoadSceneWithFade(Scenes.Title);
            Destroy(cutscene.gameObject);

            return;
        }

        StartCoroutine(FinishCutsceneRoutine(cutscene));
    }
    
    private IEnumerator FinishCutsceneRoutine(Cutscene cutscene)
    {
        yield return StartCoroutine(GameManager.Instance.ShowBlackAsync(true));

        SetSituationUI();
        Destroy(cutscene.gameObject);

        yield return StartCoroutine(GameManager.Instance.ShowBlackAsync(false));
    }

    private void SetSituationUI()
    {
        sceneUI.SetActive(true);
        episodeSlotGroupUI.gameObject.SetActive(true);

        episodeSlotGroupUI.Initialize(currentSituationData.episodeDatas);
    }
}
