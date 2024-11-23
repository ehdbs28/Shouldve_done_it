using System;
using System.Collections;
using System.Collections.Generic;
using OMG.Extensions;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Scene_WalkEpisode : EpisodeScene
{
    public Transform maleParent;
    public Transform femaleParent;
    
    public Animator maleAnimator;
    public Animator femaleAnimator;

    public GameObject mark;
    public Image markImage;

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
    private bool _callbacked;

    private WalkEpisodeEvent _curEvent;

    public List<WalkEpisodeEvent> events = new List<WalkEpisodeEvent>();

    private void Start()
    {
        // StartCoroutine(EpisodeRoutine());   
        maleAnimator.SetBool(idleHash, true);
        femaleAnimator.SetBool(idleHash, true);
    }

    protected override void OnEpisodeStart()
    {
        base.OnEpisodeStart();
        StartCoroutine(EpisodeRoutine());
        FootStepSoundLoop();
    }

    private void FootStepSoundLoop()
    {
        if(_isMoving)
            SoundManager.Instance.PlaySFX($"FootStep{Random.Range(1, 4)}");

        StartCoroutine(this.DelayCoroutine(0.5f, () => {
            FootStepSoundLoop();
        }));
    }

    private IEnumerator EpisodeRoutine()
    {
        remainEventTime = eventInterval;
        _isMoving = true;
        maleAnimator.SetBool(idleHash, false);
        femaleAnimator.SetBool(idleHash, false);
        
        while (true)
        {
            if (remainEventTime <= 0)
            {
                _callbacked = false;
                _isMoving = false;
                maleAnimator.SetBool(idleHash, true);
                femaleAnimator.SetBool(idleHash, true);
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
                    _isMoving = false;
                    maleAnimator.SetBool(idleHash, true);
                    femaleAnimator.SetBool(idleHash, true);
                    SetResult("고생은 쉽지 않았겠지만, 그 끝엔 반드시 성장이라는 선물이 기다리고 있다.", "ChatGPT", true);
                    break;
                }
            }
            
            yield return null;
        }
    }

    private void Update()
    {
        if (_isMoving || _callbacked || _curEvent == null)
        {
            return;
        }

        remainReactionTime -= Time.deltaTime;
        markImage.fillAmount = remainReactionTime / _curEvent.interactTime;
        
        if (remainReactionTime > 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CameraManager.Instance.Shake(0.2f, 0.5f);
                SetResult(null, null, true);

                SoundManager.Instance.PlaySFX("ButtonSound2");
            }
        }
        else
        {
            SetResult(_curEvent.failText, _curEvent.failAuthor, false);
        }
    }

    private void EventProcess()
    {
        var eventIdx = Random.Range(0, events.Count);
        _curEvent = events[eventIdx];

        remainReactionTime = _curEvent.interactTime;
        mark.SetActive(true);
        markImage.fillAmount = 1;
        
        _curEvent.OnProcess();
    }

    public override void SetResult(string text, string author, bool success)
    {
        _callbacked = true;
        mark.SetActive(false);
        
        _curEvent.OnResult(success);

        if (success && (text == null || author == null))
        {
            StartCoroutine(Delay());
            return;
        }
        
        base.SetResult(text, author, success);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(_curEvent.successDelay);
        maleAnimator.SetBool(idleHash, false);
        femaleAnimator.SetBool(idleHash, false);
        _isMoving = true;
    }
}