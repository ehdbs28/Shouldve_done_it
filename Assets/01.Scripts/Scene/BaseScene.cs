using UnityEngine;
using UnityEngine.Events;

public class BaseScene : MonoBehaviour
{
    [SerializeField] UnityEvent onInitializeEvent = null;
    [SerializeField] UnityEvent onReleaseEvent = null;

    [SerializeField] private Camera _camera;

    public virtual void OnPreLoadScene(Scenes next, Scenes prev)
    {
        CameraManager.Instance.SettingCamera(_camera == null ? Camera.main : _camera);
    }
    
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