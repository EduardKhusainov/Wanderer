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

            public bool IsActive { get; private set; } = false;

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

            public void SetOverlayStatus(bool isVisible) => IsActive = isVisible;

            private void OnUnpauseButtonClick()
            {
                base.Show(false, _fadeOutTime);
                SetOverlayStatus(false);
            }

            public override void Show(bool isVisible, float animationTime = 0)
            {
                base.Show(isVisible, animationTime);
                SetOverlayStatus(isVisible);
            }

            private void OnMenuButtonClick()
            {
                Show(false);
                SetOverlayStatus(false);
                SceneManager.LoadScene("MainMenu");
            }

            private void OnReloadButtonClick()
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

                Show(false);
                SetOverlayStatus(false);
                SceneManager.LoadScene(currentSceneIndex);
            }
        }
    }
}