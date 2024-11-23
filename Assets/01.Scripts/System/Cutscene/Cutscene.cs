using System;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    private PlayableDirector cutscenePlayer = null;
    private Action onCutsceneFinishedEvent = null;

    private void Awake()
    {
        cutscenePlayer = GetComponent<PlayableDirector>();
    }

    public void Play(Action callback = null)
    {
        onCutsceneFinishedEvent = callback;

        cutscenePlayer.Play();
        cutscenePlayer.stopped += HandleTimelineStopped;
    }

    private void HandleTimelineStopped(PlayableDirector director)
    {
        director.stopped -= HandleTimelineStopped;
        onCutsceneFinishedEvent?.Invoke();
        onCutsceneFinishedEvent = null;
    }
}
