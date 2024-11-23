using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class DropBook : MonoBehaviour
    {
        private void Start()
        {
            gameObject.tag = "DropBook";
        }

        private void OnCollisionEnter(Collision collision)
        {
           
        }
    }
}