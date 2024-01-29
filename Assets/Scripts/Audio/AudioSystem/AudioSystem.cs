using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Wanderer.NSUtilities;
using DG.Tweening;
using Random = UnityEngine.Random;
using System.Collections;
using Sirenix.OdinInspector;
using System.Linq;

namespace Wanderer
{
    namespace NSAudio
    {
        public class AudioSystem : PersistentSingleton<AudioSystem>
        {
            public float AudioMusicVolume { get; set; }
            public float AudioEffectsVolume { get; set; }
            public float AudioVoiceVolume { get; set; }

            public AudioSource MusicSource => _musicSource;
            public List<AudioSource> EffectSources => _effectSources;

            [SerializeField] private AudioSource _musicSource;
            [SerializeField] private List<AudioSource> _effectSources;
            [SerializeField, ReadOnly] private List<AudioClip> _musicClips;
            [SerializeField] private AudioPack _audioPack;

            private Camera _mainCamera;
            private AudioClip _lastClipPlayed;
            private Coroutine _musicAutoplayCoroutine;

            private void OnEnable()
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
            }

            private void OnDisable()
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }

            private void Start()
            {
                _musicSource.ignoreListenerPause = true;

                SetAudioSettings();

                if (!_musicSource.isPlaying)
                {
                    PlayMusic();
                }
            }

            public void Refresh()
            {
                SetAudioSettings();
            }

            public void PlayMusic(AudioClip clip = null, bool isLooping = false)
            {
                if (clip == null && _musicClips.Count <= 0) return;

                if (_musicAutoplayCoroutine != null)
                {
                    StopCoroutine(_musicAutoplayCoroutine);
                }

                AudioClip selectedClip = clip == null ? SelectRandomClip() : clip;

                _lastClipPlayed = selectedClip;
                _musicSource.loop = isLooping;
                _musicAutoplayCoroutine = StartCoroutine(PlayNextSound(selectedClip));

                AudioClip SelectRandomClip()
                {
                    List<AudioClip> excludedList = _musicClips;

                    if (_lastClipPlayed != null)
                    {
                        excludedList = _musicClips.Where(x => x != _lastClipPlayed).ToList();
                    }

                    return excludedList.Count > 0 ? excludedList[Random.Range(0, excludedList.Count)] : _musicClips[0];
                }
            }

            public void StopEffect(AudioClip clip)
            {
                foreach (var source in _effectSources)
                {
                    StopSound(source, clip);
                }
            }

            public void StopAllEffects() => StopAllSources(_effectSources);

            public void PlayEffectSound(CommonSounds key, Vector3 position)
            {
                AudioClip clip = FindClip(key);
                PlayEffectSound(clip, position);
            }

            public void PlayEffectSound(AudioClip clip, bool isLoop = false, bool randomizePitch = false)
            {
                PlayEffectSound(clip, _mainCamera.transform.position, isLoop, randomizePitch);
            }

            public void PlayEffectSound(AudioClip clip, Vector3 position, bool isLoop = false, bool randomizePitch = false)
            {
                AudioSource source = null;

                foreach (var effectSource in _effectSources)
                {
                    if (effectSource.isPlaying)
                        continue;

                    source = effectSource;
                    break;
                }

                if (source == null)
                {
                    source = _effectSources[0];
                }

                source.transform.position = position;
                PlaySoundOneShot(source, clip, isLoop, AudioEffectsVolume, randomizePitch);
            }

            public AudioClip FindClip(CommonSounds key)
            {
                foreach (var audioInfo in _audioPack.audioInfos)
                {
                    if (audioInfo.key == key)
                        return audioInfo.clip;
                }

                return null;
            }
            public void StopMusic(AudioClip clip) => StopSound(_musicSource, clip);

            public void StopAllMusic(bool smoothing = false)
            {
                _musicClips.Clear();

                StopSource(_musicSource, smoothing);
            }

            public void ChangeMusicList(IList<AudioClip> audioClips)
            {
                if (audioClips.Count == _musicClips.Count
                    && audioClips.Intersect(_musicClips).Count() == audioClips.Count())
                    return;

                _musicClips = new List<AudioClip>();
                _musicClips.AddRange(audioClips);

                if (!_musicSource.isPlaying || !audioClips.Contains(_musicSource.clip))
                {
                    PlayMusic();
                }
            }

            private void SetAudioSettings()
            {
                var settingsInstance = AudioSettings.Instance;
                var maxVolume = 100f;

                if (settingsInstance == null)
                    return;

                AudioMusicVolume = settingsInstance.MusicVolume / maxVolume;
                AudioEffectsVolume = settingsInstance.EffectsVolume / maxVolume;
                AudioVoiceVolume = settingsInstance.VoiceVolume / maxVolume;
            }

            private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
            {
                _mainCamera = Camera.main;

                if (scene.name == "MainMenu")
                {
                    StopAllEffects();
                }
            }

            private void PlaySoundOneShot(AudioSource source, AudioClip clip, bool isLoop = false, float volume = 1, bool randomizePitch = false)
            {
                if (source == null)
                {
                    Debug.LogWarning($"Null clip passed to {source.gameObject.name}", this);
                    return;
                }

                LoadClip(clip, () =>
                {
                    source.clip = clip;

                    if (randomizePitch)
                    {
                        var pitchRange = 0.1f;

                        source.pitch += Random.Range(-pitchRange, pitchRange);
                    }

                    source.volume = volume;
                    source.loop = isLoop;
                    source.Play();
                });
            }

            private void LoadClip(AudioClip clip, Action onComplete)
            {
                if (clip.loadState == AudioDataLoadState.Unloaded)
                {
                    StartCoroutine(LoadClipRoutine(clip, onComplete));
                    return;
                }

                onComplete?.Invoke();
            }

            private IEnumerator LoadClipRoutine(AudioClip clip, Action onComplete)
            {
                Debug.Log($"Clip state: {clip.loadState}", this);
                clip.LoadAudioData();

                while (clip.loadState == AudioDataLoadState.Loading)
                {
                    yield return null;
                }

                if (clip.loadState == AudioDataLoadState.Failed)
                {
                    Debug.LogError($"Failed to load audio file {clip.name}", this);
                    clip.UnloadAudioData();
                    yield break;
                }

                onComplete?.Invoke();

                yield return new WaitForSeconds(clip.length);
                clip.UnloadAudioData();
            }

            private void StopAllSources(List<AudioSource> sources, bool smoothing = false)
            {
                foreach (var source in sources)
                {
                    StopSource(source, smoothing);
                }
            }

            private void StopSound(AudioSource audioSource, AudioClip clip)
            {
                if (!audioSource.isPlaying || audioSource.clip == null) return;
                if (clip == null || audioSource.clip == clip)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                }
            }

            private void StopSource(AudioSource source, bool smoothing = false)
            {
                if (smoothing)
                {
                    source.DOFade(0, 0.5f).OnComplete(() =>
                    {
                        StopSetSource();
                        source.volume = AudioVoiceVolume;
                    });
                }
                else StopSetSource();

                void StopSetSource()
                {
                    source.Stop();
                    source.clip = null;
                }
            }

            private IEnumerator PlayNextSound(AudioClip clip)
            {
                yield return _musicSource.DOFade(0, 1f).SetUpdate(UpdateType.Normal, true).WaitForCompletion();

                LoadClip(clip, () =>
                {
                    _musicSource.clip = clip;
                    _musicSource.Play();
                });

                yield return _musicSource.DOFade(AudioMusicVolume, 1f).SetUpdate(UpdateType.Normal, true).WaitForCompletion();

                _musicSource.volume = AudioMusicVolume;

                yield return WaitForMusicEnd();
            }

            private IEnumerator WaitForMusicEnd()
            {
                if (_musicSource.clip != null)
                {
                    yield return new WaitForSecondsRealtime(_musicSource.clip.length - _musicSource.time - 1f);
                }

                _musicAutoplayCoroutine = null;
                PlayMusic();
            }
        }
    }
}