using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public enum SpeechBubbleType
    {
        Text,
        Choice
    }

    public class ChoiceInfo
    {
        public string text;
        public bool answer;
    }

    public TextSpeech textSpeech;
    public Transform canvas;

    public Transform choiceParent;
    public SpeechBubbleChoiceUnit choiceUnitPrefab;
    private List<SpeechBubbleChoiceUnit> _choices;

    public GameObject thinking;

    private Action<bool> _selectChoiceCallback;

    private Vector3 _initScale;

    private void Awake()
    {
        _initScale = transform.localScale;
    }

    public void Show(SpeechBubbleType type, bool isThinking = false, string text = "", ChoiceInfo[] choices = null, Action<bool> selectChoiceCallback = null)
    {
        gameObject.SetActive(true);
        
        thinking.SetActive(isThinking);
        _selectChoiceCallback = selectChoiceCallback;
        
        transform.DOScale(_initScale * 1.1f, 0.2f)
            .OnComplete(() => transform.DOScale(_initScale, 0.1f));
        
        textSpeech.gameObject.SetActive(type == SpeechBubbleType.Text);
        choiceParent.gameObject.SetActive(type == SpeechBubbleType.Choice);
        ClearChoices();
        
        switch (type)
        {
            case SpeechBubbleType.Text:
                WriteText(text);
                break;
            case SpeechBubbleType.Choice:
                SetChoices(choices);
                break;
        }
    }

    public void Close()
    {
        thinking.SetActive(false);
        transform.DOScale(Vector3.zero, 0.2f)
            .OnComplete(() => gameObject.SetActive(false));
    }

    private void WriteText(string text)
    {
        textSpeech.AppearText(text);
    }
    
    private void SetChoices(ChoiceInfo[] choices)
    {
        foreach (var info in choices)
        {
            var choiceUnit = Instantiate(choiceUnitPrefab, choiceParent);
            choiceUnit.Set(info, _selectChoiceCallback);
        }
    }

    private void ClearChoices()
    {
        foreach (var unit in _choices)
        {
            Destroy(unit.gameObject);
        }
        _choices.Clear();
    }
}