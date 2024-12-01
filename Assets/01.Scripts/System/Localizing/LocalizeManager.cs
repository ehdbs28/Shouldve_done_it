using System.Collections.Generic;
using UnityEngine;

public class LocalizeManager : MonoSingleton<LocalizeManager>
{
    [SerializeField] List<LocalizeTable> localizeTables = new List<LocalizeTable>();
    private Dictionary<string, LocalizeTable> localizeTableDictionary = null;

    private ELanguageType currentLanguageType = ELanguageType.NONE;

    public override void InitManager()
    {
        localizeTableDictionary = new Dictionary<string, LocalizeTable>();
        foreach(LocalizeTable table in localizeTables)
        {
            if(localizeTableDictionary.ContainsKey(table.localizeKey))
            {
                Debug.LogWarning($"A table with key {table.localizeKey} already exists");
                continue;
            }

            localizeTableDictionary.Add(table.localizeKey, table);
        }
    }

    public void SetLanguage(ELanguageType languageType)
    {
        currentLanguageType = languageType;
    }

    public string GetLocalizeString(string localizeKey)
    {
        if(localizeTableDictionary.TryGetValue(localizeKey, out LocalizeTable table) == false)
        {
            Debug.LogWarning($"A table with key {localizeKey} doesn't exists");
            return "";
        }

        return table.GetLocalizeString(currentLanguageType);
    }
}
