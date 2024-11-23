using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.LoadSceneWithFade(Scenes.Title);
    }
}
