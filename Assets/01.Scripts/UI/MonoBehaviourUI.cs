using UnityEngine;

public class MonoBehaviourUI : MonoBehaviour
{
    [SerializeField] string uiSoundName = null;

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideImmediately()
    {
        gameObject.SetActive(false);
    }

    public virtual void ShowImmediately()
    {
        gameObject.SetActive(true);
    }

    public void PlayUISound()
    {
        SoundManager.Instance.PlaySFX(uiSoundName);
    }
}
