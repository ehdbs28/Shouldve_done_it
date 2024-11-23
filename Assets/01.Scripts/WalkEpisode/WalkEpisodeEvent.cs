using UnityEngine;

public class WalkEpisodeEvent : MonoBehaviour
{
    public float interactTime;
    public virtual void OnProcess() { }
    public virtual void OnResult(bool success) { }
}