using Cinemachine;
using OMG.Extensions;
using UnityEngine;

public class SituationMenuUI : MonoBehaviourUI
{
    [SerializeField] CinemachineVirtualCamera situationMenuVCam = null;

    [Space(15f)]
    [SerializeField] float situationSlotDisplayDelay = 1f;
    [SerializeField] MonoBehaviourUI situationSlotGroupUI = null;

    private void Start()
    {
        situationSlotGroupUI.HideImmediately();
    }

    public override void Show()
    {
        base.Show();

        CameraManager.Instance.SetVirtualCamera(situationMenuVCam);
        
        situationSlotGroupUI.HideImmediately();
        StartCoroutine(this.DelayCoroutine(situationSlotDisplayDelay, situationSlotGroupUI.Show));
    }
}
