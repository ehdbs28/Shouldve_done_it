using UnityEngine;
using UnityEngine.Events;

public class BaseScene : MonoBehaviour
{
    [SerializeField] UnityEvent onInitializeEvent = null;
    [SerializeField] UnityEvent onReleaseEvent = null;

    public virtual void OnPreLoadScene(){}
    
    protected virtual void OnSceneInitialize() { }
    public void Initialize()
    {
        OnSceneInitialize();
        onInitializeEvent?.Invoke();
    }

    protected virtual void OnSceneRelease() {}
    public void Release()
    {
        OnSceneRelease();
        onReleaseEvent?.Invoke();
    }
}