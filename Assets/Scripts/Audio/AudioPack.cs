using System;
using UnityEngine;

namespace Wanderer
{
    namespace NSAudio
    {
        [CreateAssetMenu(fileName = "CommonAudioPack", menuName = "CommonAudio")]
        public class AudioPack : ScriptableObject
        {
            public AudioInfo[] audioInfos;
        }

        [Serializable]
        public class AudioInfo
        {
            public CommonSounds key;
            public AudioClip clip;
        }
    }
}
