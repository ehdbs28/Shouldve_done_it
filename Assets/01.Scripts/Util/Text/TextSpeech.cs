using UnityEngine;
using System;
using Febucci.UI;
using Febucci.UI.Core.Parsing;
using TMPro;

public class TextSpeech : MonoBehaviour
{
    private TextAnimator_TMP _textAnimator;
    private TypewriterByCharacter _typeWriter;
    public TypewriterByCharacter TypeWriter
    {
        get
        {
            if (_typeWriter == null)
            {
                Transform bodyTextTrm = transform.Find("Canvas/BodyText");
        
                _typeWriter = bodyTextTrm.GetComponent<TypewriterByCharacter>(); 
            }

            return _typeWriter;
        }
    }
    public void Setting()
    {
        Transform canvasTrm = transform.Find("Canvas");
        Transform bodyTextTrm = canvasTrm.Find("BodyText");
        
        _textAnimator = bodyTextTrm.GetComponent<TextAnimator_TMP>(); 
        _typeWriter ??= bodyTextTrm.GetComponent<TypewriterByCharacter>(); 
        
        
    }

    public void OnEnable()
    {
        TypeWriter.onMessage.AddListener(CallMessageEvent);
    }

    public void OnDisable()
    {
        TypeWriter.onMessage.RemoveListener(CallMessageEvent);
    }

    public void AppearText(string titleText, string text)
    {
        text = $"<?startEvent>{text}<?endEvent><waitfor=0.3><?soundStopEvent>";
        _typeWriter.ShowText(text);
        _typeWriter.onTextDisappeared.RemoveAllListeners();
    }
    
    public void DisappearText(Action Callback = null)
    {
        _typeWriter.StartDisappearingText();
        _typeWriter.onTextDisappeared.AddListener(() =>Callback?.Invoke());
    }

    public void CallMessageEvent(EventMarker eventMarker)
    {
        switch (eventMarker.name)
        {
            case "startEvent":
                SoundManager.Instance.PlayTalkSFX();
                break;
            case "endEvent":
                break;
            case "soundStopEvent":
                SoundManager.Instance.StopSFX();
                break;
        }
    }
}
