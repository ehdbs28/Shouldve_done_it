using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Episode.Room
{
    public class MaleCharacter : Character
    {
        [SerializeField] private TwoBoneIKConstraint LeftArmIK;
        public Scene_Room Room;

        public TwoBoneIKConstraint GetLeftArmIK() => LeftArmIK;

        public bool IsDeletingTalk;

        public void SuccessEnding()
        {
            Room.SetResult("�𸣴� ���� ���δ� ���� �� �� �� �ִ�.", "Adrian Frost", true);
        }
    }
}