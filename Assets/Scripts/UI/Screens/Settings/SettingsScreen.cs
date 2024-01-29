using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    namespace NSUI.Screen
    {
        public class SettingsScreen : BaseScreen
        {
            [Header("Buttons")]
            [SerializeField] private Button _closeButton;
            [SerializeField] private Button _muteButton;
            [SerializeField] private Slider _musicSlider;

            private Image _muteIcon;
            private NSAudio.AudioSettings _audioSettings =>
                NSAudio.AudioSettings.Instance;
            private NSAudio.AudioSystem _audioSystem =>
                 NSAudio.AudioSystem.Instance;

            private void OnDisable()
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClick);
                _muteButton.onClick.RemoveListener(OnMuteButtonClick);
                _musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
            }

            private void Awake()
            {
                _muteIcon = _muteButton.transform.Find("MuteIcon").GetComponentInChildren<Image>();
                _closeButton.onClick.AddListener(OnCloseButtonClick);
                _muteButton.onClick.AddListener(OnMuteButtonClick);
                _musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
                _canvasGroup.blocksRaycasts = false;

                SetMuteButtonView();
            }

            private void OnCloseButtonClick() => Show(false);

            public void OnMuteButtonClick()
            {
                _audioSettings.ToggleMute();
                _audioSystem.Refresh();
                SetMuteButtonView();
            }

            private void OnMusicSliderValueChanged(float value)
            {
                _audioSettings.MusicVolume = value;
                _audioSystem.MusicSource.volume = _audioSettings.MusicVolume;

                SetMuteButtonView();
            }

            private void SetMuteButtonView() =>
                _muteIcon.gameObject.SetActive(NSAudio.AudioSettings.Instance.IsMuted);

        }
    }
}