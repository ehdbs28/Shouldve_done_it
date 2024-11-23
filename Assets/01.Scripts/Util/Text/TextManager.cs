using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Core.Parsing;
using UnityEngine;
using System;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _poolStack = new Stack<T>();
    public T Obj { get;  set; }
    
    public T Pop()
    {
        if (_poolStack.TryPop(out T text))
        {
            text.gameObject.SetActive(true);
            return text;
        }
        return CreatePoolObj();
    }

    public void Push(T speech)
    {
        speech.gameObject.SetActive(false);
        _poolStack.Push(speech);
    }

    private T CreatePoolObj()
    {
        return GameObject.Instantiate(Obj); 
    }
}
public class TextManager : MonoSingleton<TextManager>
{
    [SerializeField] private TextSpeech _textSppech;
    private Pool<TextSpeech> _textSpeechPool;

    [SerializeField] private GameObject _obj;
    public override void InitManager()
    {
        _textSpeechPool = new Pool<TextSpeech>();
        _textSpeechPool.Obj = _textSppech;
    }

    public void ShowText(Vector3 startPos,string key)
    {
        TextSpeech speech = _textSpeechPool.Pop();

        string titleText = "titleText";
        string text = Define.sDialogDictionary[key];
        speech.Setting();
        speech.AppearText(titleText, text);
    }

    public void UnShowText(TextSpeech textSpeech, Action Callback = null)
    {
        _textSpeechPool.Push(textSpeech);
        Callback?.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 startPos = _obj.transform.position + new Vector3(0, 1f, 0);
            ShowText(startPos,"score");
        }
    }
}


