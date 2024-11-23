using UnityEngine;

public class IntroScene : BaseScene
{
    [SerializeField] GameObject demoUI = null;

    protected override void OnSceneInitialize()
    {
        base.OnSceneInitialize();

        if(DataManager.UserData.ProgressData.ClearedSituationList.Count > 0)
        {
            demoUI.SetActive(true);
        }
    }

    public void ResetAndKeepGoing()
    {
        DataManager.ClearData();
        DataManager.LoadData();

        demoUI.SetActive(false);
    }
}
