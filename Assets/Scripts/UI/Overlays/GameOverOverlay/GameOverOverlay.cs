using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wanderer
{
    namespace NSUI.Overlay
    {
        public class GameOverOverlay : BaseOverlay
        {
            private Button _toMenuButton;

            private void OnDisable()
            {
                _toMenuButton.onClick.RemoveListener(OnMenuButtonClick);
            }

            private void Awake()
            {
                _toMenuButton = GetComponentInChildren<Button>();
                _toMenuButton.onClick.AddListener(OnMenuButtonClick);
            }

            private void OnMenuButtonClick()
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}