using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    namespace NSUIScreens
    {
        public class MainMenuScreen : BaseScreen
        {
            [Header("Inspection Buttons")]
            [SerializeField] private Button _playButton;
            [SerializeField] private Button _settingsButton;
            [SerializeField] private SettingsScreen _settingsScreen;

            private void OnDisable()
            {
                _playButton.onClick.RemoveListener(OnPlayButtonClick);
                _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            }

            private void Awake()
            {
                _playButton.onClick.AddListener(OnPlayButtonClick);
                _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            }

            private void OnPlayButtonClick()
            {
                var sceneId = 2;

                SceneManager.LoadScene(sceneId);
            }

            private void OnSettingsButtonClick() => _settingsScreen.Show(true);
        }
    }
}