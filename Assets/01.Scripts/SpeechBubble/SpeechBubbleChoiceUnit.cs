using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleChoiceUnit : MonoBehaviour
{
    private SpeechBubble.ChoiceInfo _info;
    
    public Text _text;
    private Action<bool> _callback;

    public void Set(SpeechBubble.ChoiceInfo info, Action<bool> callback)
    {
        _info = info;
        _text.text = info.text;
        _callback = callback;
    }
    
    public void OnClick()
    {
        _callback?.Invoke(_info.answer);
    }
}