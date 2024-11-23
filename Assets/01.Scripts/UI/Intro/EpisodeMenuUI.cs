using Cinemachine;
using OMG.Extensions;
using UnityEngine;

public class EpisodeMenuUI : MonoBehaviourUI
{
    [SerializeField] CinemachineVirtualCamera episodeMenuVCam = null;

    [Space(15f)]
    [SerializeField] float episodeSlotDisplayDelay = 1f;
    [SerializeField] MonoBehaviourUI episodeSlotGroupUI = null;

    private void Start()
    {
        episodeSlotGroupUI.HideImmediately();
    }

    public override void Show()
    {
        base.Show();

        CameraManager.Instance.SetVirtualCamera(episodeMenuVCam);
        
        episodeSlotGroupUI.HideImmediately();
        StartCoroutine(this.DelayCoroutine(episodeSlotDisplayDelay, episodeSlotGroupUI.Show));
    }
}
