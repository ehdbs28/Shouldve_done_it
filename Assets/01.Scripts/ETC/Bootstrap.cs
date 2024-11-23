using OMG.Datas;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] DataLoader dataLoader = null;

    private void Awake()
    {
        dataLoader.LoadData();   
    }

    private void Start()
    {
        GameManager.Instance.LoadSceneWithFade(Scenes.Title);
    }
}
