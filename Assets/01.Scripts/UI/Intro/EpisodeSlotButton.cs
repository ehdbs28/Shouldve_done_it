using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EpisodeSlotButton : Button
{
    private EpisodeSlotUI _slot;

    protected override void Awake()
    {
        base.Awake();
        _slot = transform.parent.parent.GetComponent<EpisodeSlotUI>();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_slot.IsEnable)
        {
            _slot.title.gameObject.SetActive(true);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_slot.IsEnable)
        {
            _slot.title.gameObject.SetActive(false);
        }
    }
}