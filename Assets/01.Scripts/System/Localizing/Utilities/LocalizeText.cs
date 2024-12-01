using TMPro;
using UnityEngine;

public class LocalizeText : MonoBehaviour
{
    [SerializeField] string localizeKey = "";

    private TMP_Text text = null;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if(text == null)
            return;

        text.text = new LocalizeString(localizeKey);
    }
}
