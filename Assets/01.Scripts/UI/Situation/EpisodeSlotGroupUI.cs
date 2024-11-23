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
            CreateEpisodeSlot(episodeData);
        }
    }
    
    private void CreateEpisodeSlot(EpisodeDataSO episodeData)
    {
        EpisodeSlotUI episodeSlot = Instantiate(slotPrefab);
        episodeSlot.Initialize(episodeData);
        episodeSlot.transform.SetParent(transform);
    }
}
