public struct LocalizeString
{
    public string localizeString;

    public LocalizeString(string localizeKey)
    {
        localizeString = LocalizeManager.Instance.GetLocalizeString(localizeKey);
    }

    public static implicit operator string(LocalizeString left) => left.localizeString;
}