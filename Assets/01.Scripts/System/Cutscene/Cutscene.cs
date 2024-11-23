using System;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    private PlayableDirector cutscenePlayer = null;
    private Action<Cutscene> onCutsceneFinishedEvent = null;

    private void Awake()
    {
        cutscenePlayer = GetComponent<PlayableDirector>();
    }

    public void Play(Action<Cutscene> callback = null)
    {
        onCutsceneFinishedEvent = callback;

        cutscenePlayer.Play();
        cutscenePlayer.stopped += HandleTimelineStopped;
        Debug.Log("->Play");
    }

    private void HandleTimelineStopped(PlayableDirector director)
    {
        Debug.Log("-->HandleTimelineStopped");
        director.stopped -= HandleTimelineStopped;
        onCutsceneFinishedEvent?.Invoke(this);
        onCutsceneFinishedEvent = null;
    }
}
