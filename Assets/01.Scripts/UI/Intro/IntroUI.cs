using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    [SerializeField] MonoBehaviourUI blockPanelUI = null;
    [SerializeField] MonoBehaviourUI titleUI = null;
    [SerializeField] MonoBehaviourUI episodeMenuUI = null;
    [SerializeField] GameObject settingButtonUI = null;

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
        settingButtonUI.SetActive(false);

        episodeMenuUI.Show();
    }

    public void OnTouchSettingButton()
    {
        DataManager.UserData.SettingData.LanguageType = ELanguageType.NONE;
        GameManager.Instance.LoadSceneWithFade(Scenes.Title);
    }
}
