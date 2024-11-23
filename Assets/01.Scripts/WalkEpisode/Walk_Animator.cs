using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Animator : MonoBehaviour
{
    protected Animator _animator;
    protected readonly int _speedHash =  Animator.StringToHash("speed");

    public void Setting()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetSpeed(float value)
    {
        _animator.SetFloat(_speedHash, value);
    }
}
