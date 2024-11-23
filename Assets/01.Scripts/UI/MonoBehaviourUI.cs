using UnityEngine;

public class MonoBehaviourUI : MonoBehaviour
{
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
}
