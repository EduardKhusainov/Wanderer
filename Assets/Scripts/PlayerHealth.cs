using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class PlayerHealth : MonoBehaviour, IDamagable, IHeal
    {
        float _playerCurrentHealth;
        public float playerMaxHealth;
        [SerializeField] TextMeshProUGUI _playerHealthText;
        //[SerializeField] Slider _hpSlider;
        [SerializeField] Material hpBarMaterial;
        [SerializeField] GameObject go;
        private void Start()
        {
            _playerCurrentHealth = playerMaxHealth;
            //_hpSlider.value = _playerCurrentHealth;
            _playerHealthText.text = playerMaxHealth.ToString();
            hpBarMaterial = go.GetComponent<Renderer>().material;
        }

        public void TakeDamage(float value)
        {
            if(_playerCurrentHealth > 0 && _playerCurrentHealth != 0)
            {
                _playerCurrentHealth -= value;
                if(_playerCurrentHealth <= 0)
                {
                    _playerCurrentHealth = 0;
                    _playerHealthText.text = _playerCurrentHealth.ToString();
                     gameObject.SetActive(false);
                    ShowDeathScreen();
                }
                //_hpSlider.value = _playerCurrentHealth;
                float multPerc = 100/playerMaxHealth;
                float percent = multPerc *_playerCurrentHealth/100;
                hpBarMaterial.SetFloat("_Percentage", percent);
                _playerHealthText.text = _playerCurrentHealth.ToString();
            }
        }

        public void Heal(float value)
        {
            _playerCurrentHealth += value;
            float multPerc = 100/playerMaxHealth;
            float percent = multPerc *_playerCurrentHealth/100;
            hpBarMaterial.SetFloat("_Percentage", percent);
            //_hpSlider.value = _playerCurrentHealth;
            _playerCurrentHealth = Mathf.Clamp(_playerCurrentHealth, 0, playerMaxHealth);

            _playerHealthText.text = _playerCurrentHealth.ToString();
        }

        private void ShowDeathScreen()
        {
            var canvas = CanvasManager.Instance.SetCanvases[1].GetComponent<GameOverOverlay>();
            var coinsAmount = transform.GetComponent<PlayerFinance>().Amount;
            var fadeDelay = 1.6f;

            canvas.SetCoinsAmount(coinsAmount);
            canvas.Show(true, fadeDelay);
        }
    }
}
