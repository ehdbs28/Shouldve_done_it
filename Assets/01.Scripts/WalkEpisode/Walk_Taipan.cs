using System;
using UnityEngine;
using DG.Tweening;

public class Walk_Taipan : MonoBehaviour
{
    public void Set(Vector3 position)
    {
        transform.position = position + new Vector3(5, 0, 0);
        transform.DOMove(position, 0.5f);
    }
}