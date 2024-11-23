using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour
{
    [SerializeField] private Text _text;

    public CanvasGroup canvasGroup;

    private Action _callback;
    

    public void Show(string text, bool force, Action callback = null)
    {
        _callback = callback;

        gameObject.SetActive(true);

        if (force)
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, 0.5f);
        }

        _text.text = text;
        StartCoroutine(Seq());
    }

    private IEnumerator Seq()
    {
        yield return new WaitForSeconds(5f);
        Close();
    }

    private void Close()
    {
        canvasGroup.DOFade(0, 2f)
            .OnComplete(() =>
            {
                _callback?.Invoke();
                gameObject.SetActive(false);
            });
    }
}