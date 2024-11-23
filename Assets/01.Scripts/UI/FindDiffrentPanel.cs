using System;
using UnityEngine;

public class FindDiffrentPanel : MonoBehaviourUI
{
    public SkinnedMeshRenderer femaleRenderer;

    public Material prevMat;
    public Material initMat;

    public bool[] answer;
    public bool[] myAnswer;

    public bool callbacked;
    public bool success;
    
    public void Show(bool[] ans)
    {
        answer = ans;
        myAnswer = new bool[ans.Length];
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            femaleRenderer.material = prevMat;
            SoundManager.Instance.PlaySFX("ButtonSound2");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            femaleRenderer.material = initMat;
            SoundManager.Instance.PlaySFX("ButtonSound2");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            success = true;
            for (var i = 0; i < answer.Length; i++)
            {
                if (answer[i] != myAnswer[i])
                {
                    success = false;
                    break;
                }
            }
            callbacked = true;
            SoundManager.Instance.PlaySFX("ButtonSound2");
        }
    }

    public void SetAnswer(int index)
    {
        myAnswer[index] = !myAnswer[index];
    }
}