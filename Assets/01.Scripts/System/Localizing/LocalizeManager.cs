using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LocalizeManager : MonoSingleton<LocalizeManager>
{
    [SerializeField] ELanguageType defaultLanguage = ELanguageType.NONE;
    [SerializeField] TextAsset localizeData = null;
    private Dictionary<string, LocalizeTable> localizeTables = null;

    private ELanguageType currentLanguageType = ELanguageType.NONE;

    public override void InitManager()
    {
        List<LocalizeTable> localizeDatas = JsonConvert.DeserializeObject<List<LocalizeTable>>(localizeData.text);
        localizeTables = new Dictionary<string, LocalizeTable>();
        foreach(LocalizeTable table in localizeDatas)
        {
            if(localizeTables.ContainsKey(table.localizeKey))
            {
                Debug.LogWarning($"A table with key {table.localizeKey} already exists");
                continue;
            }

            localizeTables.Add(table.localizeKey, table);
        }

        SetLanguage(defaultLanguage);
    }

    public void SetLanguage(ELanguageType languageType)
    {
        currentLanguageType = languageType;
    }

    public string GetLocalizeString(string localizeKey)
    {
        if(localizeTables.TryGetValue(localizeKey, out LocalizeTable table) == false)
        {
            Debug.LogWarning($"A table with key {localizeKey} doesn't exists");
            return localizeKey;
        }

        return table.GetLocalizeString(currentLanguageType);
    }
}
