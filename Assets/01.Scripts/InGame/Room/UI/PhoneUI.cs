using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Episode.Room
{
    public class PhoneUI : UIPanel
    {
        [SerializeField] private float ShowTime;

        [Space]
        public UnityEvent OnDeleteTalkEvent;
        
        [Space]
        public Text tooltipText;

        private Vector2 OriginPos;

        protected override void Awake()
        {
            base.Awake();

            OriginPos = Rect.anchoredPosition;
        }

        public override void Show()
        {
            base.Show();
            // tooltipText.text = "";

            Rect
                .DOAnchorPos(Vector2.zero, ShowTime)
                .SetEase(Ease.OutBack)
                .OnComplete(() => {
                    SetTooltipText();
                });
        }

        public override void Hide()
        {
            Rect.DOAnchorPos(OriginPos, ShowTime).SetEase(Ease.InBack);
        }

        public void OnDelete()
        {
            OnDeleteTalkEvent?.Invoke();
        }

        private void SetTooltipText()
        {
            tooltipText.text = new LocalizeString("episode_room_tooltip_slide");
        }
    }
}