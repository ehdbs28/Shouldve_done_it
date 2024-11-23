using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float MaxTime;
    private float CurrentTime;
    private Coroutine TimerCo;

    public UnityEvent OnTimeOverEvent;

    private void Awake()
    {
        ResetTimer();
    }

    public void StartTimer()
    {
        if(TimerCo == null)
            TimerCo = StartCoroutine(CountTime());
    }

    public void PauseTimer()
    {
        if(TimerCo != null)
        {
            StopCoroutine(TimerCo);
            TimerCo = null;
        }
    }

    public void ResetTimer()
    {
        CurrentTime = MaxTime;
    }

    private void TimeOver()
    {
        StopCoroutine(TimerCo);
        TimerCo = null;

        OnTimeOverEvent.Invoke();

        ResetTimer();
    }

    private IEnumerator CountTime()
    {
        while(true)
        {
            yield return null;

            CurrentTime -= Time.deltaTime;
            
            if(CurrentTime <= 0.0f)
            {
                TimeOver();
            }
        }
    }
}