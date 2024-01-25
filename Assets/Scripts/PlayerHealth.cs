using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    public class PlayerHealth : MonoBehaviour, IDamagable, IHeal
    {
        float _playerCurrentHealth;
        [SerializeField] float _playerMaxHealth;
        [SerializeField] TextMeshProUGUI _playerHealthText;
        [SerializeField] Slider _hpSlider;

        private void Start()
        {
            _playerCurrentHealth = _playerMaxHealth;
            _hpSlider.value = _playerCurrentHealth;
            _playerHealthText.text = _playerMaxHealth.ToString();
        }
        public void TakeDamage(float value)
        {
            _playerCurrentHealth -= value;
            _hpSlider.value = _playerCurrentHealth;
            _playerHealthText.text = _playerCurrentHealth.ToString();
        }

        public void Heal(float value)
        {
            _playerCurrentHealth += value;
            _hpSlider.value = _playerCurrentHealth;
            _playerCurrentHealth = Mathf.Clamp(_playerCurrentHealth, 0, _playerMaxHealth);

            _playerHealthText.text = _playerCurrentHealth.ToString();
        }
    }
}
