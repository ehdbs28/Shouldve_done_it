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
        gameObject.SetActive(true);
        _canvasGroup.alpha = 0f;
        _canvasGroup.DOFade(1, 5f);
        _text.text = text;
        _author.text = author;
    }

    public void Close(bool force = false)
    {
        if (force)
        {
            Destroy(this.gameObject);
            return;
        }
        
        _canvasGroup.DOFade(0, 2f)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
            });
    }
}
