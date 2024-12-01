using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Episode.Room
{
    public class MaleCharacterHead : MonoBehaviour
    {
        [SerializeField] private MaleCharacter OwnerCharacter;

        [Space]
        [SerializeField] private Text tooltipText;
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("DropBook"))
            {
                Debug.Log("hti book");
                OwnerCharacter.GetAnim().SetTrigger("stand_up");
                OwnerCharacter.GetLeftArmIK().weight = 0.0f;
                GetComponent<Collider>().enabled = false;

                SoundManager.Instance.PlaySFX("Hit");
                SetTooltipText();
            }
        }

        private void SetTooltipText()
        {
            string body = new LocalizeString("episode_room_tooltip_touch");
            string content = new LocalizeString("episode_room_tooltip_touch_phone");
            tooltipText.text = string.Format(body, content);
        }
    }
}
