using Cinemachine;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    [SerializeField] MonoBehaviourUI blockPanelUI = null;
    [SerializeField] MonoBehaviourUI titleUI = null;
    [SerializeField] MonoBehaviourUI episodeMenuUI = null;

    [Space(15f)]
    [SerializeField] CinemachineVirtualCamera introVCam = null;

    private void Awake()
    {
        CameraManager.Instance.SetVirtualCamera(introVCam);
    }

    public void OnTouchTabToStartButton()
    {
        blockPanelUI.Hide();
        titleUI.Hide();

        episodeMenuUI.Show();
    }
}
