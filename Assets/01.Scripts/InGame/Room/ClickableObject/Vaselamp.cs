using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Episode.Room
{
    public class Vaselamp : ClickableObject
    {
        [SerializeField] private Light Light;
        [SerializeField] private Text tooltipText;

        private void Start()
        {
            SetTooltipText();
        }

        protected override void OnMouseDown()
        {
            if (Priority > CurrentPriority) return;

            base.OnMouseDown();

            Light.enabled = false;
            tooltipText.text = "";
        }

        private void SetTooltipText()
        {
            string body = new LocalizeString("episode_room_tooltip_touch");
            string content = new LocalizeString("episode_room_tooltip_touch_lamp");
            tooltipText.text = string.Format(body, content);
        }
    }
}