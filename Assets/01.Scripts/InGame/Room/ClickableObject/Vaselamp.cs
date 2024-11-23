using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class Vaselamp : ClickableObject
    {
        [SerializeField] private Light Light;

        protected override void OnMouseDown()
        {
            base.OnMouseDown();

            Light.enabled = false;
        }
    }
}