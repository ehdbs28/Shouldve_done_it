using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void WakeUp()
        {
            GetAnim().SetTrigger("wake_up");

            PhoneUI.Hide();
        }

        public void OnWakeUp()
        {
            if (MaleCharacter.IsDeletingTalk)
            {
                //start talk
                ShowDeletingSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "�� ���ϳ�?");

                StartCoroutine(ShowDeleingEnding());
            }
            else
            {
                //stand up
                StandUp();
            }
        }

        private IEnumerator ShowDeleingEnding()
        {
            yield return new WaitForSeconds(2f);

            Room.SetResult("��Ų �߸��� ������ �ƴ϶� �밡�� �䱸�Ѵ�.", "Serena Vale", false);
        }

        public void StandUp()
        {
            GetAnim().SetTrigger("stand_up");
        }

        public void OnStandUp()
        {
            GetAnim().SetTrigger("walk");
            
            //go to phone
            var seq = DOTween.Sequence();
            seq.Append(transform.DOMove(MovePoints[0].position, Vector3.Distance(MovePoints[0].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            seq.Join(transform.DORotate(MovePoints[0].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            seq.Append(transform.DOMove(MovePoints[1].position, Vector3.Distance(MovePoints[1].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            seq.Join(transform.DORotate(MovePoints[1].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            seq.Append(transform.DOMove(MovePoints[2].position, Vector3.Distance(MovePoints[2].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            seq.Join(transform.DORotate(MovePoints[2].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            seq.AppendCallback(() =>
            {
                GetAnim().SetTrigger("idle");
            });
            seq.Append(transform.DOMove(MovePoints[3].position, Vector3.Distance(MovePoints[3].position, transform.position) / MoveSpeed)).SetEase(Ease.Linear);
            seq.Join(transform.DORotate(MovePoints[3].eulerAngles, 0.1f)).SetEase(Ease.Linear);
            seq.AppendCallback(() =>
            {
                //start talk
                ShowPhoneSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, true, "�� ���� �ٶ��ǰ��־���...");
            });
            seq.AppendInterval(2f);
            seq.AppendCallback(() =>
            {
                Room.SetResult("�𸣴� ���� ���� �ູ������, �˰� �� �Ŀ��� ������ �ٲ�� �Ѵ�.", "Rowan Blake", false);
            });

            seq.SetAutoKill(true);

            ClickableObject.CurrentPriority = -1;
        }
    }
}
