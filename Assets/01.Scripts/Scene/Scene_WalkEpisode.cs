using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Scene_WalkEpisode : EpisodeScene
{
    public Transform maleParent;
    public Transform femaleParent;
    
    public Animator maleAnimator;
    public Animator femaleAnimator;

    public readonly int idleHash = Animator.StringToHash("idle");
    
    public readonly int male_left_walk_hash = Animator.StringToHash("male_left_walk");
    public readonly int male_terrified = Animator.StringToHash("male_terrified");
    public readonly int male_battlecry = Animator.StringToHash("male_battlecry");

    public readonly int female_terrified = Animator.StringToHash("female_terrified");

    public float movingTime = 30f;
    public float eventInterval = 5f;
    private float remainEventTime;

    private float remainReactionTime;

    private bool _isMoving;

    private WalkEpisodeEvent _curEvent;

    public List<WalkEpisodeEvent> events = new List<WalkEpisodeEvent>();

    private void Start()
    {
        StartCoroutine(EpisodeRoutine());   
    }

    protected override void OnEpisodeStart()
    {
        base.OnEpisodeStart();
        StartCoroutine(EpisodeRoutine());
    }

    private IEnumerator EpisodeRoutine()
    {
        remainEventTime = eventInterval;
        _isMoving = true;
        
        while (true)
        {
            if (remainEventTime <= 0)
            {
                _isMoving = false;
                EventProcess();
                remainEventTime = eventInterval;
            }

            if (_isMoving)
            {
                maleParent.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                femaleParent.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
                remainEventTime -= Time.deltaTime;
                movingTime -= Time.deltaTime;

                if (movingTime <= 0f)
                {
                    break;
                }
            }
            
            yield return null;
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            return;
        }

        remainReactionTime -= Time.deltaTime;
        
        if (remainReactionTime > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SetResult(true);
        }
        else
        {
            SetResult(false);
        }
    }

    private void EventProcess()
    {
        maleAnimator.SetBool(idleHash, false);
        femaleAnimator.SetBool(idleHash, false);
        
        var eventIdx = Random.Range(0, events.Count);
        _curEvent = events[eventIdx];

        remainReactionTime = _curEvent.interactTime;
        
        _curEvent.OnProcess();
    }

    public override void SetResult(bool success)
    {
        _curEvent.OnResult(success);

        if (success)
        {
            _isMoving = true;
            maleAnimator.SetBool(idleHash, true);
            femaleAnimator.SetBool(idleHash, true);
            return;
        }
        
        base.SetResult(success);
    }
}