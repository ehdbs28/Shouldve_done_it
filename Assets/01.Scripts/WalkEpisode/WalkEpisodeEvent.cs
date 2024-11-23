using UnityEngine;

public class WalkEpisodeEvent : MonoBehaviour
{
    public float successDelay = 5f;
    public float interactTime;
    public string failText;
    public string failAuthor;

    public virtual void OnProcess()
    {
    }

    public virtual void OnResult(bool success)
    {
    }
}