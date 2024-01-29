using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wanderer
{
    namespace NSUI.Overlay
    {
        public class GameOverOverlay : BaseOverlay
        {
            [SerializeField] private TextMeshProUGUI _coinsText;

            private Button _toMenuButton;
            private int _coinsAmount;

            private void OnDisable()
            {
                _toMenuButton.onClick.RemoveListener(OnMenuButtonClick);
            }

            private void Awake()
            {
                _toMenuButton = GetComponentInChildren<Button>();
                _toMenuButton.onClick.AddListener(OnMenuButtonClick);
            }

            public void SetCoinsAmount(int amount) =>
                _coinsAmount = amount;

            public override void Show(bool isVisible, float animationTime = 0)
            {
                base.Show(isVisible, animationTime);

                _coinsText.text = _coinsAmount.ToString();
            }

            private void OnMenuButtonClick()
            {
                SceneManager.LoadScene("MainMenu");
                Show(false);
            }
        }
    }
}