using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Wanderer.NSUI.Overlay;
using Wanderer.NSUI.Screen;

namespace Wanderer
{
    public class PlayerHealth : MonoBehaviour, IDamagable, IHeal
    {
        float _playerCurrentHealth;
        public float playerMaxHealth;
        [SerializeField] TextMeshProUGUI _playerHealthText;
        [SerializeField] TextMeshPro _textMinusPlayerHP;
        [SerializeField] Material hpBarMaterial;
        [SerializeField] GameObject go;
        [SerializeField] PlayerStats playerStats;
        [SerializeField] Animator animator;
        [SerializeField] RuntimeAnimatorController minusHP;
        [SerializeField] RuntimeAnimatorController minusHP2;
        [SerializeField] ParticleSystem psisHitted;
        [SerializeField] ParticleSystem psCircle;
        bool isPlay;
        private void Start()
        {
            playerMaxHealth = playerStats.playerMaxHealth;
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
                if(isPlay)
                {
                    animator.runtimeAnimatorController = minusHP;
                    isPlay = false;
                    psisHitted.Stop();
                    psisHitted.Play();
                    psCircle.Stop();
                    psCircle.Play();
                }
                if(!isPlay)
                {
                    animator.runtimeAnimatorController = minusHP2;
                    isPlay = true;
                    psisHitted.Stop();
                    psisHitted.Play();
                    psCircle.Stop();
                    psCircle.Play();
                }
                _textMinusPlayerHP.text = "-" + " " + value.ToString();
                if(_playerCurrentHealth <= 0)
                {
                    _playerCurrentHealth = 0;
                    _playerHealthText.text = _playerCurrentHealth.ToString();
                     gameObject.SetActive(false);
                    ShowDeathScreen();
                }
               ResetHPBar();
            }
        }

        public void Heal(float value)
        {
            _playerCurrentHealth += value;
            if(_playerCurrentHealth > playerMaxHealth)
            {
                _playerCurrentHealth = playerMaxHealth;
            }
            ResetHPBar();
        }

        public void ShowDeathScreen()
        {
            var canvas = CanvasManager.Instance.SetCanvases[1].GetComponent<GameOverOverlay>();
            var coinsAmount = transform.GetComponent<PlayerFinance>()._money;
            var fadeDelay = 1.6f;

            canvas.SetCoinsAmount(coinsAmount);
            canvas.Show(true, fadeDelay);
        }
        
        public void ResetHPBar() 
        {
            playerMaxHealth = playerStats.playerMaxHealth;
            float multPerc = 100/playerMaxHealth;
            float percent = multPerc *_playerCurrentHealth/100;
            hpBarMaterial.SetFloat("_Percentage", percent);
            _playerHealthText.text = _playerCurrentHealth.ToString(); 
        }
    }
}
