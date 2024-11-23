using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Episode.Room
{
    public class PhoneUI : UIPanel
    {
        [SerializeField] private float ShowTime;

        [Space]
        public UnityEvent OnDeleteTalkEvent;

        private Vector2 OriginPos;

        protected override void Awake()
        {
            base.Awake();

            OriginPos = Rect.anchoredPosition;
        }

        public override void Show()
        {
            base.Show();

            Rect.DOAnchorPos(Vector2.zero, ShowTime).SetEase(Ease.OutBack);
        }

        public override void Hide()
        {
            Rect.DOAnchorPos(OriginPos, ShowTime).SetEase(Ease.InBack);
        }

        public void OnDelete()
        {
            OnDeleteTalkEvent?.Invoke();
        }
    }
}