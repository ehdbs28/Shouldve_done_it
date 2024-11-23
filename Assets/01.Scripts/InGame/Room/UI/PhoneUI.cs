using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Episode.Room
{
    public class PhoneUI : UIPanel
    {
        [SerializeField] private float ShowTime;

        private Vector2 OriginPos;

        protected override void Awake()
        {
            base.Awake();

            OriginPos = Rect.rect.position;
        }

        public override void Show()
        {
            base.Show();

            Rect.DOAnchorPos(Vector2.zero, ShowTime).SetEase(Ease.OutBack);
        }

        public override void Hide()
        {
            base.Hide();

            Rect.DOAnchorPos(Vector2.zero, ShowTime).SetEase(Ease.InBack);
        }
    }
}