using System.Collections.Generic;
using OMG.Utility;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SituationData")]
public class SituationDataSO : ScriptableObject
{
    public string situationName = "";
    public Sprite situationThumbnail = null;
    public OptOption<Cutscene> cutscenePrefabs = null;
    public List<EpisodeDataSO> episodeDatas = new List<EpisodeDataSO>();
}
