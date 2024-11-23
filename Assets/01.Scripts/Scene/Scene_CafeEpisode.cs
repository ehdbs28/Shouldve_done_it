using System;
using System.Collections;
using UnityEngine;

public class Scene_CafeEpisode : EpisodeScene
{
    public Animator femaleAnimator;
    public Animator maleAnimator;
    
    public SpeechBubble femaleSpeechBubble;
    public SpeechBubble maleSpeechBubble;

    public SpeechBubble.ChoiceInfo[] firstChoice;

    private bool _callbacked;
    private bool _success;

    private readonly int female_disbelief_hash = Animator.StringToHash("female_disbelief");
    private readonly int female_clap_hash = Animator.StringToHash("female_clap");
    private readonly int male_disbelief_hash = Animator.StringToHash("male_disbelief");
    private readonly int male_clap_hash = Animator.StringToHash("male_clap");
    
    
    private void Start()
    {
        StartCoroutine(EpisodeRoutine());
    }

    protected override void OnEpisodeStart()
    {
        base.OnEpisodeStart();
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            femaleSpeechBubble.Close();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            maleSpeechBubble.Close();
        }
    }

    private IEnumerator EpisodeRoutine()
    {
        femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "나 어디 달라진거 없어?");
        yield return new WaitForSeconds(2f);
        
        femaleSpeechBubble.Close();
        yield return new WaitForSeconds(1f);
        
        femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "오늘 무슨날인지 알고 있지?");
        yield return new WaitForSeconds(2f);

        _callbacked = false;
        maleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Choice, true, choices: firstChoice, selectChoiceCallback:
            success =>
            {
                _success = success;
                _callbacked = true;
            });

        yield return new WaitUntil(() => _callbacked);
        
        femaleSpeechBubble.Close();
        maleSpeechBubble.Close();

        yield return new WaitForSeconds(1f);

        if (_success)
        {
            femaleAnimator.SetTrigger(female_clap_hash);
            maleAnimator.SetTrigger(male_clap_hash);
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "맞아 ㅎㅎ 그냥 말해봤어~~");
        }
        else
        {
            femaleAnimator.SetTrigger(female_disbelief_hash);
            maleAnimator.SetTrigger(male_disbelief_hash);
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "그냥 말해본건데.. 관심이 있기는 해?");
        }
    }
}