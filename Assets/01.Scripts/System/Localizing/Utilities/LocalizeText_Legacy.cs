using UnityEngine.UI;
using UnityEngine;

public class LocalizeText_Legacy : MonoBehaviour
{
    [SerializeField] string localizeKey = "";

    private Text text = null;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        if(text == null)
            return;

        text.text = new GetLocalizeString(localizeKey);
    }
}
