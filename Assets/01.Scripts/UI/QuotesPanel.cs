using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuotesPanel : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _author;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(string text, string author)
    {
        _canvasGroup.DOFade(0, 0.5f);
        _text.text = text;
        _author.text = author;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _canvasGroup.DOFade(0, 0.5f)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
    }
}
