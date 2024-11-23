using System.Collections;
using System.Collections.Generic;
using Febucci.UI.Core.Parsing;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _poolStack = new Stack<T>();
    public T Obj { get;  set; }
    
    public T Pop()
    {
        if (_poolStack.TryPop(out T text))
        {
            return text;
        }

        return CreatePoolObj();
    }

    public void Push(TextSpeech speech)
    {
        
    }

    private T CreatePoolObj()
    {
        return GameObject.Instantiate(Obj); 
    }
}
public class TextManager : MonoSingleton<TextManager>
{
    [SerializeField] private TextSpeech _textSppech;
    private Pool<TextSpeech> _textSppechPool;

    [SerializeField] private GameObject _obj;
    public override void InitManager()
    {
        _textSppechPool = new Pool<TextSpeech>();
        _textSppechPool.Obj = _textSppech;
    }

    public void ShowText(Vector3 startPos,string key)
    {
        TextSpeech speech = _textSppechPool.Pop();

        string titleText = "titleText";
        string text = Define.sDialogDictionary[key];
        // speech.Setting();
        // speech.AppearText(titleText, text);
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


