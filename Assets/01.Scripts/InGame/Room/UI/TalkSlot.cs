using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Episode.Room
{
    public class TalkSlot : UIObject
    {
        [SerializeField] private float ReturnTime;
        private bool OnDragging;
        private Vector2 DragStartPos;
        private Vector2 OriginLocalPos;

        protected override void Awake()
        {
            base.Awake();

            OriginLocalPos = Rect.anchoredPosition;
        }

        private void Update()
        {
            if(OnDragging)
            {
                Vector2 Pos = new Vector2(
                        OriginLocalPos.x + Mathf.Max(0f, Input.mousePosition.x - DragStartPos.x),
                        OriginLocalPos.y
                    );
                Rect.anchoredPosition = Pos;
            }
        }

        private void StartDrag()
        {
            DragStartPos = Input.mousePosition;

            OnDragging = true;
        }

        private void EndDrag()
        {
            OnDragging = false;

            Rect.DOAnchorPos(OriginLocalPos, ReturnTime);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            StartDrag();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            EndDrag();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);

            EndDrag();
        }
    }
}
