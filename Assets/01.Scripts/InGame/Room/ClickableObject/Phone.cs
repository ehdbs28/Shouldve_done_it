using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class Phone : ClickableObject
    {
        [SerializeField] private PhoneUI PhoneUI;

        protected override void OnMouseDown()
        {
            if (Priority > CurrentPriority) return;

            base.OnMouseDown();

            PhoneUI.Show();
        }
    }
}