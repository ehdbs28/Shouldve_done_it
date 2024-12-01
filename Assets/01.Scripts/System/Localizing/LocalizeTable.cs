[System.Serializable]
public class LocalizeTable
{
    public string localizeKey = "";
    public string korean = "";
    public string english = "";
    public string japanese = "";

    public string GetLocalizeString(ELanguageType languageType)
    {
        return languageType switch {
            ELanguageType.Korean => korean,
            ELanguageType.English => english,
            ELanguageType.Japanese => japanese,
            _ => ""
        };
    }
}