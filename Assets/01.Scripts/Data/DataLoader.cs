using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace OMG.Datas
{
    public class DataLoader : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] AudioMixer audioMixer = null;
    
        #if UNITY_EDITOR
        public UserData UserData = null;
        #endif

        public void LoadData()
        {
            DataManager.LoadData();

            Dictionary<string, float> volumeMap = DataManager.UserData.SettingData.VolumeMap;
            foreach(string volumeKey in volumeMap.Keys)
            {
                audioMixer.SetFloat(volumeKey, volumeMap[volumeKey]);
                Debug.Log(volumeMap[volumeKey]);
            }
            
            #if UNITY_EDITOR
            UserData = DataManager.UserData;
            #endif
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        ClearData();
                    }
                }
            }
        }

        private void OnDestroy()
        {
            DataManager.SaveData();    
        }

        [ContextMenu("ClearData")]
        public void ClearData()
        {
            DataManager.ClearData();
            DataManager.LoadData();
        }
    }
}
