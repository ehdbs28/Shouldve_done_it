using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class ClickableObject : MonoBehaviour
    {
        public static int CurrentPriority;

        [SerializeField] protected int Priority;
        [SerializeField] private bool PriorityIncreaseObject;

        protected virtual void OnMouseDown() 
        {
            if (Priority > CurrentPriority) return;

            if (PriorityIncreaseObject)
                CurrentPriority++;
        }
    }
}