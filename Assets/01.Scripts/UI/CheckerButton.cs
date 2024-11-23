using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckerButton : CustomButton, ISubmitHandler
{
    private bool _check;
    private Image _checkImage;
    
    protected override void Awake()
    {
        base.Awake();
        _checkImage = transform.Find("Check").GetComponent<Image>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _check = !_check;
        _checkImage.gameObject.SetActive(_check);
    }
}