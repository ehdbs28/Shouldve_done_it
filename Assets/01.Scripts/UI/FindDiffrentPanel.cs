using System;
using UnityEngine;

public class FindDiffrentPanel : MonoBehaviour
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
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            femaleRenderer.material = initMat;
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
        }
    }

    public void SetAnswer(int index)
    {
        myAnswer[index] = !myAnswer[index];
    }
}