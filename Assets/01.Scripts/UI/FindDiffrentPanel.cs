using System;
using UnityEngine;

public class FindDiffrentPanel : MonoBehaviour
{
    public GameObject female;
    
    public void Show()
    {
        
    }

    public void Close()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            female.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            female.SetActive(false);
        }
    }
}