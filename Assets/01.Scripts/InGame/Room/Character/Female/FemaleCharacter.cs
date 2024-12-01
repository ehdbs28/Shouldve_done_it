using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Episode.Room
{
    public class FemaleCharacter : Character
    {
        public Scene_Room Room;
        [SerializeField] private MaleCharacter MaleCharacter;
        [SerializeField] private PhoneUI PhoneUI;
        [SerializeField] private List<Transform> MovePoints;
        [SerializeField] private float MoveSpeed;

        [SerializeField] private SpeechBubble ShowDeletingSpeechBubble;
        [SerializeField] private SpeechBubble ShowPhoneSpeechBubble;
        public PlayableDirector PD;

        public void WakeUp()
        {
            ClickableObject.CurrentPriority = -1;

            PhoneUI.Hide();

            if (MaleCharacter.IsDeletingTalk)
            {
                GetAnim().SetTrigger("wake_up");
            }
            else
            {
                //stand up
                StandUp();
            }
        }

        public void OnWakeUp()
        {
            if (MaleCharacter.IsDeletingTalk)
            {
                //start talk
                // string value = Define.sDialogDictionary["roomBubbleWhat"];
                string value = new LocalizeString("episode_room_fail_girl_content_awake");
                ShowDeletingSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, value);

                StartCoroutine(ShowDeleingEnding());
            }
            else
            {
                //stand up
                //StandUp();
            }
        }

        private IEnumerator ShowDeleingEnding()
        {
            yield return new WaitForSeconds(2f);

            string keyBody = "episode_room_fail_phrase_{0}_awake";
            Room.SetResult(
                new LocalizeString(string.Format(keyBody, "content")), 
                new LocalizeString(string.Format(keyBody, "auth")), 
                false
            );
        }

        public void StandUp()
        {
            PD.Play();

            //GetAnim().SetTrigger("stand_up");
        }

        public void CheckPhone()
        {
            StartCoroutine(CheckPhoneCo());
        }

        private IEnumerator CheckPhoneCo()
        {
            string value = new LocalizeString("episode_room_fail_girl_content_sleep");
            ShowPhoneSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, true, value);

            yield return new WaitForSeconds(2f);

            // Room.SetResult("��Ų �߸��� ������ �ƴ� �밡�� �䱸�Ѵ�.", "Rowan Blake", false);
            string keyBody = "episode_room_fail_phrase_{0}_sleep";
            Room.SetResult(
                new LocalizeString(string.Format(keyBody, "content")), 
                new LocalizeString(string.Format(keyBody, "auth")), 
                false
            );
        }

        public void OnStandUp()
        {
            //GetAnim().SetTrigger("walk");

            //go to phone
            //var seq = DOTween.Sequence();
            //seq.Append(transform.DOMove(MovePoints[0].position, Vector3.Distance(MovePoints[0].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            //seq.Join(transform.DORotate(MovePoints[0].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            //seq.Append(transform.DOMove(MovePoints[1].position, Vector3.Distance(MovePoints[1].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            //seq.Join(transform.DORotate(MovePoints[1].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            //seq.Append(transform.DOMove(MovePoints[2].position, Vector3.Distance(MovePoints[2].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            //seq.Join(transform.DORotate(MovePoints[2].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            //seq.AppendCallback(() =>
            //{
            //    GetAnim().SetTrigger("idle");
            //});
            //seq.Append(transform.DOMove(MovePoints[3].position, Vector3.Distance(MovePoints[3].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            //seq.Join(transform.DORotate(MovePoints[3].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            //seq.AppendCallback(() =>
            //{
            //    //start talk
            //    ShowPhoneSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, true, "?? ???? ???????????...");
            //});
            //seq.AppendInterval(2f);
            //seq.AppendCallback(() =>
            //{
            //    Room.SetResult("??? ???? ???? ????????, ??? ?? ?��??? ?????? ???? ???.", "Rowan Blake", false);
            //});

            //seq.SetAutoKill(true);
            //PD.Play();
        }
    }
}
