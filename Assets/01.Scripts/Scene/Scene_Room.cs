using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class Scene_Room : EpisodeScene
    {
        [Space]
        [SerializeField] private Timer FemaleWakeUpTimer;
        [SerializeField] private Character FemaleCharacter;

        protected override void OnEpisodeStart()
        {
            base.OnEpisodeStart();

            ClickableObject.CurrentPriority = 1;
        }

        private void Start()
        {
            FemaleWakeUpTimer.OnTimeOverEvent.AddListener(WakeUpFemale);
            StartFemaleWakeUpTimer();
        }

        public void StartFemaleWakeUpTimer()
        {
            FemaleWakeUpTimer.StartTimer();
        }

        private void WakeUpFemale()
        {
            FemaleCharacter.GetAnim().SetTrigger("stand_up");
        }
    }
}

