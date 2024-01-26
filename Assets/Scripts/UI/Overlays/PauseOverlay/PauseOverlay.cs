using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wanderer
{
    namespace NSUI.Overlay
    {
        public class PauseOverlay : BaseOverlay
        {
            [Header("Inspection Buttons")]
            [SerializeField] private Button _unpauseButton;
            [SerializeField] private Button _menuButton;
            [SerializeField] private Button _reloadButton;

            [Header("Configurations")]
            [SerializeField] private float _fadeOutTime;

            private void OnDisable()
            {
                _unpauseButton.onClick.RemoveListener(OnUnpauseButtonClick);
                _menuButton.onClick.RemoveListener(OnMenuButtonClick);
                _reloadButton.onClick.RemoveListener(OnReloadButtonClick);
            }

            private void Awake()
            {
                _unpauseButton.onClick.AddListener(OnUnpauseButtonClick);
                _menuButton.onClick.AddListener(OnMenuButtonClick);
                _reloadButton.onClick.AddListener(OnReloadButtonClick);
            }

            private void OnUnpauseButtonClick()
            {
                Show(false, _fadeOutTime);
            }

            private void OnMenuButtonClick()
            {
                SceneManager.LoadScene("MainMenu");
            }

            private void OnReloadButtonClick()
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

                SceneManager.LoadScene(currentSceneIndex);
            }
        }
    }
}