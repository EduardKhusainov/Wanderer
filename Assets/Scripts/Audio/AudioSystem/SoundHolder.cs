using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    namespace NSAudio
    {
        public class SoundHolder : MonoBehaviour
        {
            [SerializeField] private List<AudioClip> _audioClips;

            private AudioSystem _audioSystem;

            private void Awake()
            {
                _audioSystem = AudioSystem.Instance;
            }

            private void Start()
            {
                _audioClips.RemoveAll(i => i == null);

                if (_audioClips.Count <= 0)
                {
                    Debug.LogWarning("Missing Audio: no audio clips passed or audio clips are null", this);
                    _audioSystem.StopAllMusic(true);
                    return;
                }

                _audioSystem.ChangeMusicList(_audioClips);
            }
        }
    }
}