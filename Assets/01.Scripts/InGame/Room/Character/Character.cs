using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Episode.Room
{
    public class Character : MonoBehaviour
    {
        private Animator Anim;
        public Animator GetAnim() => Anim;

        private void Start()
        {
            gameObject.tag = "Character";

            Anim = GetComponent<Animator>();
        }
    }
}