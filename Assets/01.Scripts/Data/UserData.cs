[System.Serializable]
public class UserData
{
    public UserSettingData SettingData = null;
    public UserProgressData ProgressData = null;

    public void CreateData()
    {
        SettingData = new UserSettingData();
        ProgressData = new UserProgressData();
    }
}
