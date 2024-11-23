using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Episode.Room
{
    public class MaleCharacter : Character
    {
        [SerializeField] private TwoBoneIKConstraint LeftArmIK;
        public TwoBoneIKConstraint GetLeftArmIK() => LeftArmIK;
    }
}