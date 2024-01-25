using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    public class AudioAdministrator : MonoBehaviour
    {
        public static AudioAdministrator Instance
        { get; private set; }

        public Slider soundSlider;
        public Slider musicSlider;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                soundSlider.value = PlayerPrefs.GetFloat("SoundVolumeSave");
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolumeSave");
                soundSlider.onValueChanged.AddListener(SaveSoundVolume);
                musicSlider.onValueChanged.AddListener(SaveMusicVolume);
            }


        }
        public void SaveSoundVolume(float value)
        {
            PlayerPrefs.SetFloat("SoundVolumeSave", value);
            PlayerPrefs.Save();
        }

        public void SaveMusicVolume(float value)
        {
            PlayerPrefs.SetFloat("MusicVolumeSave", value);
            PlayerPrefs.Save();
        }
    }
}

