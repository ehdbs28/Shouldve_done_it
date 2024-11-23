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

        [Space]
        [SerializeField] private float DeleteDistance;
        [SerializeField] private bool IsDelete;

        protected override void Awake()
        {
            base.Awake();

            OriginLocalPos = Rect.anchoredPosition;
        }

        private void Update()
        {
            if (IsDelete)
                return;

            if(OnDragging)
            {
                Vector2 Pos = new Vector2(
                        OriginLocalPos.x + Mathf.Max(0f, Input.mousePosition.x - DragStartPos.x),
                        OriginLocalPos.y
                    );
                Rect.anchoredPosition = Pos;

                if(Rect.anchoredPosition.x - OriginLocalPos.x >= DeleteDistance)
                {
                    Delete();
                }
            }
        }

        private void StartDrag()
        {
            DragStartPos = Input.mousePosition;

            OnDragging = true;
        }

        private void EndDrag()
        {
            if (IsDelete)
                return;

            OnDragging = false;
            
            Rect.DOAnchorPos(OriginLocalPos, ReturnTime);
        }

        private void Delete()
        {
            IsDelete = true;

            Rect.DOAnchorPos(Rect.anchoredPosition + 500f * Vector2.right, ReturnTime).OnComplete(() =>
            {
                Destroy(gameObject);
            });
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
