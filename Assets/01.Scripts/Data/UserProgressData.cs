using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class UserProgressData
{
    public HashSet<string> ClearedSituationList = null;
    public int CurrentEpisodeIndex = 0;

    [JsonIgnore] 
    public SituationDataSO CurrentSituationData = null;

    public UserProgressData()
    {
        ClearedSituationList = new HashSet<string>();
    }
}
