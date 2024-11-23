using System.Collections.Generic;
using UnityEngine;

public class EpisodeSlotGroupUI : MonoBehaviourUI
{
    [SerializeField] EpisodeSlotUI slotPrefab = null;

    public void Initialize(List<EpisodeDataSO> episodeDatas)
    {
        for(int i = 0; i < episodeDatas.Count; ++ i)
        {
            EpisodeDataSO episodeData = episodeDatas[i];
            EpisodeSlotUI ui = CreateEpisodeSlot(episodeData);

            ui.SetEnable(DataManager.UserData.ProgressData.CurrentEpisodeIndex == 0);
        }
    }
    
    private EpisodeSlotUI CreateEpisodeSlot(EpisodeDataSO episodeData)
    {
        EpisodeSlotUI episodeSlot = Instantiate(slotPrefab);
        episodeSlot.Initialize(episodeData);
        episodeSlot.transform.SetParent(transform);

        return episodeSlot;
    }
}
