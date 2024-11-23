using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour
{
    [SerializeField] private Text _text;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(string text)
    {
        var seq = DOTween.Sequence();
        seq.Append(_canvasGroup.DOFade(1, 0.5f));
        seq.AppendInterval(1f).OnComplete(Close);
        _text.text = text;
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