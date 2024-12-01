using System.Collections.Generic;

[System.Serializable]
public class UserSettingData
{
    public Dictionary<string, float> VolumeMap = null;
    public ELanguageType LanguageType = ELanguageType.NONE;

    public UserSettingData()
    {
        VolumeMap = new Dictionary<string, float>() {
            ["Master"] = 0.5f,
            ["SFX"] = 0.5f,
            ["BGM"] = 0.5f
        };

        LanguageType = ELanguageType.NONE;
    }
}
