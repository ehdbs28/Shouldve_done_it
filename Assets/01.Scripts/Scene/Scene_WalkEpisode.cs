using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Scene_WalkEpisode : EpisodeScene
{
    [field: SerializeField] public  Walk_Character Female { get; private set; }
    [field: SerializeField] public Walk_Character Male { get; private set; }
    [SerializeField] private Walk_Taipan _taipan;
    [SerializeField] private Walk_TimeEventSO _eventTimeSO;
    
    private float[] _targetTimes;
    private float _timer = 0f;
    private int _eventIndex = 0;

    private Coroutine _reactionCoroutine;

    public event Action OnDogEvent;
    public event Action OnGirlEvent;
    public event Action OnFailEvent;

    private Action[] _actions = new Action[3];
    
    public bool OnTimer { get; private set; }
    public bool CanReaction { get; private set; }

    private void Awake()
    {
        OnSceneInitialize();
        //CameraManager.Instance.
    }
    protected override void OnSceneInitialize()
    {
        //base.OnSceneInitialize();
        CanReaction = false;
        _eventIndex = 0;
        _targetTimes = new float[3];

        Female.Setting(this);
        Male.Setting(this);
        _taipan.Setting(this);
        
        _actions = new Action[3];
        _actions[0] = OnGirlEvent;  
        _actions[1] = OnDogEvent; 
        
        _targetTimes[0] = Random.Range(1f, 4.5f);
        _targetTimes[1] = Random.Range(1f, 4.5f);

        OnTimer = true;
    }

    private void Update()
    {
        if (OnTimer)
        {
            _timer += Time.deltaTime;
            if (_timer >= _targetTimes[_eventIndex])
            {
                if(_reactionCoroutine != null)
                    StopCoroutine(_reactionCoroutine);
                
                _reactionCoroutine = StartCoroutine(ReactionCor(_eventIndex));
                _eventIndex++;                
                _timer = 0f;
                OnTimer = false;
            }
        }

        if (CanReaction)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_reactionCoroutine != null)
                {
                    StopCoroutine(_reactionCoroutine);
                    CanReaction = false;
                }
            }
        }
    }
    private IEnumerator ReactionCor(int index)
    {
        float offset = _targetTimes[index];
        
        CanReaction = true;
        yield return new WaitForSeconds(offset);
        CanReaction = false;
    }
    public void Failed()
    {
        Debug.Break();
        OnFailEvent?.Invoke();
    }
}