using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class Scene_Room : EpisodeScene
    {
        [Space]
        [SerializeField] private Timer FemaleWakeUpTimer;
        [SerializeField] private FemaleCharacter FemaleCharacter;

        protected override void OnEpisodeStart()
        {
            base.OnEpisodeStart();

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

