using UnityEngine;
using System;
using Febucci.UI;
using TMPro;
public class TextSpeech : MonoBehaviour
{
    private TextAnimator_TMP _textAnimator;
    private TypewriterByCharacter _typeWriter;
    
    public void Awake()
    {
        _textAnimator = GetComponent<TextAnimator_TMP>(); 
        _typeWriter = GetComponent<TypewriterByCharacter>(); 
    }

    public void AppearText(string text)
    {
        _typeWriter.ShowText(text);
        _typeWriter.onTextDisappeared.RemoveAllListeners();
    }

    public void DisappearText(Action Callback = null)
    {
        _typeWriter.StartDisappearingText();
        _typeWriter.onTextDisappeared.AddListener(() =>Callback?.Invoke());
    }

}
