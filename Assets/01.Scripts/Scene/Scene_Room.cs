using UnityEngine;

namespace Episode.Room
{
    public class Scene_Room : EpisodeScene
    {
        [Space]
        [SerializeField] private Timer FemaleWakeUpTimer;
        [SerializeField] private FemaleCharacter FemaleCharacter;

        public override void OnPreLoadScene(Scenes next, Scenes prev)
        {
            base.OnPreLoadScene(next, prev);
            ClickableObject.CurrentPriority = 1;
        }

        private void Start()
        {
            FemaleWakeUpTimer.OnTimeOverEvent.AddListener(FemaleCharacter.WakeUp);
            StartFemaleWakeUpTimer();
        }

        public void StartFemaleWakeUpTimer()
        {
            FemaleWakeUpTimer.StartTimer();
        }

        public void PauseFemaleWakeUpTimer()
        {
            FemaleWakeUpTimer.PauseTimer();
        }
    }
}

