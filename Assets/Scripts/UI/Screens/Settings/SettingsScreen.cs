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

            private void OnDisable()
            {
                _closeButton.onClick.RemoveListener(OnCloseButtonClick);
                _muteButton.onClick.RemoveListener(OnMuteButtonClick);
            }

            private void Awake()
            {
                _closeButton.onClick.AddListener(OnCloseButtonClick);
                _muteButton.onClick.AddListener(OnMuteButtonClick);
                _canvasGroup.blocksRaycasts = false;
            }

            private void OnCloseButtonClick() => Show(false);

            private void OnMuteButtonClick()
            {
                var muteIcon = _muteButton.transform.Find("MuteIcon").GetComponentInChildren<Image>();

                muteIcon.gameObject.SetActive(!muteIcon.gameObject.activeSelf);
            }
        }
    }
}