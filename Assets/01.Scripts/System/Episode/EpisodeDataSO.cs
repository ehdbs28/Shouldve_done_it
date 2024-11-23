using UnityEngine;

[CreateAssetMenu(menuName = "SO/EpisodeData")]
public class EpisodeDataSO : ScriptableObject
{
    public Scenes sceneType = Scenes.None;
    public string episodeName = "";
    public Sprite episodeThumbnail = null;
    public EpisodeScene episodePrefab = null;
}
