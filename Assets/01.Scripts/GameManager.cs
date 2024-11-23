using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {
        InitManager();
    }
    public override void InitManager()
    {
        TextManager.Instance.InitManager();
    }

}
