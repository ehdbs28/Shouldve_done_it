using UnityEngine;

public class IntroScene : BaseScene
{
    [SerializeField] GameObject demoUI = null;

    public override void OnPreLoadScene(Scenes next, Scenes prev)
    {
        base.OnPreLoadScene(next, prev);
     
        if (DataManager.UserData.ProgressData.ClearedSituationList.Count > 0)
        {
            demoUI.SetActive(true);
            return;
        }

        demoUI.SetActive(false);
    }

    public void ResetAndKeepGoing()
    {
        DataManager.ClearData();
        DataManager.LoadData();

        demoUI.SetActive(false);
    }
}
