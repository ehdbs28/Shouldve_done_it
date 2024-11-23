using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuotesPanel : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _author;

    public void Show(string text, string author)
    {
        _text.text = text;
        _author.text = author;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
