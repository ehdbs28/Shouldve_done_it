using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class Phone : ClickableObject
    {
        protected override void OnMouseDown()
        {
            base.OnMouseDown();

            Debug.Log("click phone");
        }
    }
}