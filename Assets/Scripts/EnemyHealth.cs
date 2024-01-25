using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    public class EnemyHealth : MonoBehaviour, IDamagable
    {
        private float _enemyCurrentHealth;
        [SerializeField] float _enemyMaxHealth;
        [SerializeField] Slider _hpSlider;
        [SerializeField] GameObject coin;

        private void Start()
        {
            _enemyCurrentHealth = _enemyMaxHealth;
        }
        public void TakeDamage(float value)
        {
            _enemyCurrentHealth -= value;
            _hpSlider.value = _enemyCurrentHealth;
            if (_enemyCurrentHealth <= 0)
                Death();
        }

        void Death()
        {
            Destroy(gameObject);
            Instantiate(coin, transform.position, coin.transform.rotation);
        }
    }
}
