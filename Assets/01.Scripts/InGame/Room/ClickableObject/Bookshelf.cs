using Episode.Room;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEditor;

namespace Episode.Room
{
    public class Bookshelf : ClickableObject
    {
        [SerializeField] private GameObject DropBook;

        [Space]
        [SerializeField] private float ShakeDuration;
        [SerializeField] private float ShakeDelay;
        [SerializeField] private Vector3 ShakeOffset;
        private bool IsShaked;

        protected override void OnMouseDown()
        {
            if (Priority > CurrentPriority) return;
            if (IsShaked) return;

            base.OnMouseDown();

            StartCoroutine(Shake());

            IsShaked = true;
        }

        private IEnumerator Shake()
        {
            float CurTime = 0f;
            float PrevShakeTime = 0f;
            Vector3 OriginPos = transform.position;

            while(true)
            {
                yield return null;

                CurTime += Time.deltaTime;

                //Shake
                if(CurTime - PrevShakeTime > ShakeDelay)
                {
                    Vector3 RandomPos = new Vector3(
                        Random.Range(-ShakeOffset.x, ShakeOffset.x),
                        Random.Range(-ShakeOffset.y, ShakeOffset.y),
                        Random.Range(-ShakeOffset.z, ShakeOffset.z)
                    );

                    transform.position = OriginPos + RandomPos;

                    PrevShakeTime = CurTime;
                }

                if (CurTime >= ShakeDuration)
                    break;
            }

            transform.position = OriginPos;

            DoDropBook();
        }

        private void DoDropBook()
        {
            DropBook.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}