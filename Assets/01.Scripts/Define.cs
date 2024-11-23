using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Define
{
    public static Dictionary<string, string> sDialogDictionary;
    public static AudioListener sAudioListener => Camera.main.GetComponent<AudioListener>();
    static Define()
    {
        sDialogDictionary = new Dictionary<string, string>();

        TextTable textTable = (TextTable)GameDataManager.GetTable(TABLE.TextTable);


        for (int i = 0; i < textTable.Count; ++i)
        {
            TextTableProb prob = textTable.Datas[i];
            sDialogDictionary.Add(prob.TextID, prob.Korean);
            Debug.Log($"TextId: {prob.TextID}  Korean: {prob.Korean} ");
        }
    }
    
    public static string GetAppearText(string key)
    {
        return sDialogDictionary[key];
    }
}
