using OMG.Extensions;
using UnityEngine;

public class WalkEpisodeEvent : MonoBehaviour
{
    public float successDelay = 5f;
    public float interactTime;
    public string failText;
    public string failAuthor;

    public virtual void OnProcess()
    {
        SoundManager.Instance.PlaySFX("Alert");
        StartCoroutine(this.DelayCoroutine(0.1f, () => {
            SoundManager.Instance.PlaySFX("Scream");
        }));
    }

    public virtual void OnResult(bool success)
    {
        if(success)
            SoundManager.Instance.PlaySFX("SimpleSuccess");
    }
}