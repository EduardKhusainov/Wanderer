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

            private void OnDisable()
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClick);
                _muteButton.onClick.RemoveListener(OnMuteButtonClick);
            }

            private void Awake()
            {
                _muteIcon = _muteButton.transform.Find("MuteIcon").GetComponentInChildren<Image>();
                _closeButton.onClick.AddListener(OnCloseButtonClick);
                _muteButton.onClick.AddListener(OnMuteButtonClick);
                _canvasGroup.blocksRaycasts = false;

                SetMuteButtonView();
            }

            private void OnCloseButtonClick() => Show(false);

            private void OnMuteButtonClick()
            {
                var audioSettings = NSAudio.AudioSettings.Instance;
                var audioSystem = NSAudio.AudioSystem.Instance;

                audioSettings.ToggleMute();
                audioSystem.MusicSource.volume = audioSettings.MusicVolume;

                SetMuteButtonView();
            }

            private void SetMuteButtonView() =>
                _muteIcon.gameObject.SetActive(NSAudio.AudioSettings.Instance.IsMuted);
        }
    }
}