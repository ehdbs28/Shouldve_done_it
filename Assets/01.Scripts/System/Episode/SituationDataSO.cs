using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SituationData")]
public class SituationDataSO : ScriptableObject
{
    public string situationName = "";
    public Sprite situationThumbnail = null;
    public Cutscene cutscenePrefab = null;
    public List<EpisodeDataSO> episodeDatas = new List<EpisodeDataSO>();
}
