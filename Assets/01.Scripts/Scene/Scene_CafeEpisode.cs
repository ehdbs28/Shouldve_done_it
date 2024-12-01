using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Scene_CafeEpisode : EpisodeScene
{
    public Animator femaleAnimator;
    public Animator maleAnimator;
    
    public SpeechBubble femaleSpeechBubble;
    public SpeechBubble maleSpeechBubble;

    public SpeechBubble.ChoiceInfo[] firstChoice;
    public SpeechBubble.ChoiceInfo[] secondChoice;

    public FindDiffrentPanel findDifferentPanel;

    private bool _callbacked;
    private bool _success;

    private int tempAnswer;

    private readonly int female_disbelief_hash = Animator.StringToHash("female_disbelief");
    private readonly int female_clap_hash = Animator.StringToHash("female_clap");
    private readonly int male_disbelief_hash = Animator.StringToHash("male_disbelief");
    private readonly int male_clap_hash = Animator.StringToHash("male_clap");
    
    
    private void Start()
    {
        // StartCoroutine(EpisodeRoutine());
    }

    protected override void OnEpisodeStart()
    {
        base.OnEpisodeStart();
        StartCoroutine(EpisodeRoutine());
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
        ////////////////////////////////
        // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "나 어디 달라진거 없어?");
        femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_1_question"));
        yield return new WaitForSeconds(2f);
        
        femaleSpeechBubble.Close();
        yield return new WaitForSeconds(1f);

        var initPos = CameraManager.Instance.Camera.transform.position;
        var initRot = CameraManager.Instance.Camera.transform.rotation;
        CameraManager.Instance.SetPosition(new Vector3(1.72f, 1.52f, -0.5f), 2f);
        CameraManager.Instance.SetRotation(Quaternion.Euler(0, 180f, 0f), 2f, () =>
        {
            findDifferentPanel.Show(new[] { true, true, true });
        });
        
        yield return new WaitUntil(() => findDifferentPanel.callbacked);
        findDifferentPanel.Close();
        
        CameraManager.Instance.SetPosition(initPos, 2f);
        CameraManager.Instance.SetRotation(initRot, 2f);

        yield return new WaitForSeconds(3f);
        
        if (findDifferentPanel.success)
        {
            femaleAnimator.SetTrigger(female_clap_hash);
            maleAnimator.SetTrigger(male_clap_hash);
            // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "잘 보고 있었구나~!!");
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_1_answer"));
            SoundManager.Instance.PlaySFX("ClapSound");
        }
        else
        {
            femaleAnimator.SetTrigger(female_disbelief_hash);
            maleAnimator.SetTrigger(male_disbelief_hash);
            // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "그럴 줄 알았어..");
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_1_wrong"));
            
            yield return new WaitForSeconds(2f);
            
            // SetResult("눈썰미를 기르는 것, 그것은 삶의 작은 디테일 속에서 진실을 발견하는 능력을 키우는 일이다.", "Emilio Capriccio", false);
            string keyBody = "episode_cafe_dialog_1_phrase";
            SetResult(new LocalizeString($"{keyBody}_content"), new LocalizeString($"{keyBody}_auth"), false);
            yield break;
        }
        
        yield return new WaitForSeconds(4f);
            
        ///////////////////////////////
        // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "오늘 무슨날인지 알고 있지?");
        femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_2_question"));
        yield return new WaitForSeconds(2f);

        _callbacked = false;
        maleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Choice, true, choices: firstChoice, selectChoiceCallback:
            (success, index) =>
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
            // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "맞아 ㅎㅎ 그냥 말해봤어~~");
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_2_answer"));
            SoundManager.Instance.PlaySFX("ClapSound");
        }
        else
        {
            femaleAnimator.SetTrigger(female_disbelief_hash);
            maleAnimator.SetTrigger(male_disbelief_hash);
            // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "그냥 말해본건데.. 관심이 있기는 해?");
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_2_wrong"));
            
            yield return new WaitForSeconds(2f);
            
            // SetResult("여자의 마음은 바다처럼 깊고 이해하기 어렵다.", "Gabriel García Márquez", false);
            string keyBody = "episode_cafe_dialog_2_phrase";
            SetResult(new LocalizeString($"{keyBody}_content"), new LocalizeString($"{keyBody}_auth"), false);
            yield break;
        }
        
        yield return new WaitForSeconds(4f);

        ////////////////////////////////
        
        // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "나보다 예쁜 여자가 사귀자 하면 어떡할거야?");
        femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_3_question"));
        yield return new WaitForSeconds(2f);
        
        _callbacked = false;
        var selectIdx = 0;
        tempAnswer = Random.Range(0, secondChoice.Length);
        secondChoice[tempAnswer].answer = true;
        maleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Choice, true, choices: secondChoice, selectChoiceCallback:
            (success, select) =>
            {
                selectIdx = select;
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
            // femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, "음.. 정답은 아니지만 뭐 ㅋㅋ");
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, new LocalizeString("episode_cafe_dialog_3_answer"));
            SoundManager.Instance.PlaySFX("ClapSound");
            
            yield return new WaitForSeconds(2f);
        
            // SetResult("여자의 마음을 이해하시다니,\n참으로 깊은 배려와 섬세함이 느껴집니다.", "Chat GPT", true);
            string keyBody = "episode_cafe_complete_phrase";
            SetResult(new LocalizeString($"{keyBody}_content"), new LocalizeString($"{keyBody}_auth"), true);
        }
        else
        {
            femaleAnimator.SetTrigger(female_disbelief_hash);
            maleAnimator.SetTrigger(male_disbelief_hash);

            // var text = selectIdx switch
            // {
            //     0 => "나는 어쩌고?",
            //     1 => "그건 너무 거짓말이다 ㅋㅋㅋ",
            //     2 => "세상에 예쁜 사람이 얼마나 많은데"
            // };
            var text = new LocalizeString($"episode_cafe_dialog_3_wrong_{selectIdx + 1}");
            
            femaleSpeechBubble.Show(SpeechBubble.SpeechBubbleType.Text, false, text);
            
            yield return new WaitForSeconds(2f);
            
            // SetResult("정답이 없는 것도 있다. 그저 살아가며 찾아가는 것이 답일 때도 있다.", "Elizabeth Novak", false);
            string keyBody = "episode_cafe_dialog_3_phrase";
            SetResult(new LocalizeString($"{keyBody}_content"), new LocalizeString($"{keyBody}_auth"), false);
        }
    }
}