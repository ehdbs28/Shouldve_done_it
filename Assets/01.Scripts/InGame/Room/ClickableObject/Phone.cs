using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Episode.Room
{
    public class Phone : ClickableObject
    {
        [Space]
        [SerializeField] private int TalkCount;
        public UnityEvent OnDeleteAllTalkEvent;

        [Space]
        [SerializeField] private PhoneUI PhoneUI;

        [Space]
        [SerializeField] private MaleCharacter MaleCharacter;

        protected override void OnMouseDown()
        {
            if (Priority > CurrentPriority) return;
            if (TalkCount <= 0) return;

            base.OnMouseDown();

            PhoneUI.Show();

            MaleCharacter.IsDeletingTalk = true;
        }

        public void DeleteTalk()
        {
            TalkCount--;

            if (TalkCount == 0)
            {
                PhoneUI.Hide();
                
                OnDeleteAllTalkEvent?.Invoke(); //상황 종료
            }
        }
    }
}