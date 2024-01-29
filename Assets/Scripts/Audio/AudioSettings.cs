using UnityEngine;
using Wanderer.NSUtilities;

namespace Wanderer
{
    namespace NSAudio
    {
        public class AudioSettings : PersistentSingleton<AudioSettings>
        {
            [SerializeField] private float _musicVolume;
            [SerializeField] private float _effectsVolume;
            [SerializeField] private float _voiceVolume;

            private bool _isMuted;

            public float MusicVolume
            {
                get => _isMuted ? 0 : _musicVolume;
                set => _musicVolume = value;
            }

            public float EffectsVolume
            {
                get => _isMuted ? 0 : _effectsVolume;
                set => _effectsVolume = value;
            }

            public float VoiceVolume
            {
                get => _isMuted ? 0 : _voiceVolume;
                set => _voiceVolume = value;
            }

            public bool IsMuted
            {
                get => _isMuted;
                set => _isMuted = value;
            }

            public void ToggleMute()
            {
                var audio = AudioSystem.Instance;
                IsMuted = !IsMuted;
                audio.Refresh();
            }
        }
    }
}