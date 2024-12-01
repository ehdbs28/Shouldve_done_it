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
            // Room.SetResult("모르는 것이 때로는 약이 될 수도 있다.", "Adrian Frost", true);
            Room.PauseFemaleWakeUpTimer();

            string keyBody = "episode_room_success_phrase";
            Room.SetResult(
                new LocalizeString($"{keyBody}_content"),
                new LocalizeString($"{keyBody}_auth"),
                true
            );
        }
    }
}