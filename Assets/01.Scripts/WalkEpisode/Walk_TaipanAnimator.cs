using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_TaipanAnimator : MonoBehaviour
{
    protected Animator _animator;
    protected readonly int _attackHash =  Animator.StringToHash("attack");
    protected readonly int _deadHash   =  Animator.StringToHash("dead");    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
        _animator.SetTrigger(_attackHash);
    }

    public void DeadAnimation()
    {
        _animator.SetTrigger(_deadHash);
    }
}
