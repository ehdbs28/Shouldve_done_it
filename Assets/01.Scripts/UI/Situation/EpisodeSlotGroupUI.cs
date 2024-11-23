using System.Collections.Generic;
using UnityEngine;

public class EpisodeSlotGroupUI : MonoBehaviourUI
{
    [SerializeField] EpisodeSlotUI slotPrefab = null;
    [SerializeField] private Vector3[] positions;

    public void Initialize(List<EpisodeDataSO> episodeDatas)
    {
        var uis = GetComponentsInChildren<EpisodeSlotUI>();
        for(int i = 0; i < episodeDatas.Count; ++ i)
        {
            EpisodeDataSO episodeData = episodeDatas[i];
            var ui = uis[i];

            ui.Initialize(episodeData);
            ui.SetEnable(DataManager.UserData.ProgressData.CurrentEpisodeIndex == i);
        }
    }
    
    private EpisodeSlotUI CreateEpisodeSlot(EpisodeDataSO episodeData, int i)
    {
        EpisodeSlotUI episodeSlot = Instantiate(slotPrefab);
        episodeSlot.transform.SetParent(transform);
        episodeSlot.transform.position = positions[i];

        return episodeSlot;
    }
}
