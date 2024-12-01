using UnityEngine;

public class LanguageSelectUI : MonoBehaviourUI
{
    private void Awake()
    {
        if(DataManager.UserData.SettingData.LanguageType == ELanguageType.NONE)
            return;

        gameObject.SetActive(false);
    }

    public void SelectLanguage(int languageIndex)
    {
        ELanguageType languageType = (ELanguageType)languageIndex;
        LocalizeManager.Instance.SetLanguage(languageType);
        GameManager.Instance.LoadSceneWithFade(Scenes.Title);
    }
}
