using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Episode.Room
{
    public class ClickableObject : MonoBehaviour
    {
        public static int CurrentPriority;

        [SerializeField] protected int Priority;
        [SerializeField] private bool PriorityIncreaseObject;
        [SerializeField] private string soundName = null;

        public UnityEvent OnClickedEvent;

        protected virtual void OnMouseDown() 
        {
            if (Priority > CurrentPriority) return;

            if (PriorityIncreaseObject)
                CurrentPriority++;

            OnClickedEvent.Invoke();
            SoundManager.Instance.PlaySFX(soundName);
        }
    }
}