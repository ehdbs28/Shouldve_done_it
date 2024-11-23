using Newtonsoft.Json;
using UnityEngine;

public static class DataManager
{
    public static UserData UserData = null;
    private const string DATA_KEY = "UserData";

    public static void LoadData()
    {
        string dataToLoad = PlayerPrefs.GetString(DATA_KEY, "");
        UserData = JsonConvert.DeserializeObject<UserData>(dataToLoad);
        if (UserData == null)
            CreateData();
    }

    public static void SaveData()
    {
        string dataToStore = JsonConvert.SerializeObject(UserData);
        PlayerPrefs.SetString(DATA_KEY, dataToStore);
    }

    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(DATA_KEY);
    }

    private static void CreateData()
    {
        UserData = new UserData();
        UserData.CreateData();
    }
}
