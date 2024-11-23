using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Episode.Room
{
    public class MaleCharacterHead : MonoBehaviour
    {
        [SerializeField] private MaleCharacter OwnerCharacter;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("DropBook"))
            {
                Debug.Log("hti book");
                OwnerCharacter.GetAnim().SetTrigger("stand_up");
                OwnerCharacter.GetLeftArmIK().weight = 0.0f;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
