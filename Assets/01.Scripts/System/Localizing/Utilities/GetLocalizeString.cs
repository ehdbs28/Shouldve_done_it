public struct GetLocalizeString
{
    public string localizeString;

    public GetLocalizeString(string localizeKey)
    {
        localizeString = LocalizeManager.Instance.GetLocalizeString(localizeKey);
    }

    public static implicit operator string(GetLocalizeString left) => left.localizeString;
}