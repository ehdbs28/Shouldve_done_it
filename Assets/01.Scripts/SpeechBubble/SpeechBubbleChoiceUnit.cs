using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubbleChoiceUnit : MonoBehaviour
{
    private SpeechBubble.ChoiceInfo _info;
    
    public Text _text;
    private Action<bool, int> _callback;
    private int _index;

    public void Set(SpeechBubble.ChoiceInfo info, int index, Action<bool, int> callback)
    {
        _index = index;
        _info = info;
        _text.text = info.text;
        _callback = callback;
    }
    
    public void OnClick()
    {
        _callback?.Invoke(_info.answer, _index);
    }
}