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

            public float MusicVolume { get => _musicVolume; set => _musicVolume = value; }
            public float EffectsVolume { get => _effectsVolume; set => _effectsVolume = value; }
            public float VoiceVolume { get => _voiceVolume; set => _voiceVolume = value; }
        }
    }
}
