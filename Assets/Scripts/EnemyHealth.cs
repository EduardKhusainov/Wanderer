using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Wanderer
{
    public class EnemyHealth : MonoBehaviour, IDamagable
    {
        public float _enemyCurrentHealth;
        [SerializeField] float _enemyMaxHealth;
        [SerializeField] Slider _hpSlider;
        [SerializeField] GameObject coin;
        private EnemyAnimator enemyAnimator;
        public ParticleSystem psEnemeDeath;
        public SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] Material hpBarMaterial;
        [SerializeField] GameObject go;
        [SerializeField] GameObject mainGo;
        bool isDeath;
        PlayerStats playerStats;
        PlayerHealth playerHealth;

        private void Start()
        {
            _enemyCurrentHealth = _enemyMaxHealth;
            hpBarMaterial = go.GetComponent<Renderer>().material;
            playerStats = FindObjectOfType<PlayerStats>();
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
        public void TakeDamage(float value)
        {
            if(_enemyCurrentHealth > 0 && _enemyCurrentHealth != 0)
            {
                _enemyCurrentHealth -= value;
            }
            if(_enemyCurrentHealth <= 0 && !isDeath)
            {
                _enemyCurrentHealth = 0;
                Death();
                isDeath = true;
            }
            

            float multPerc = 100/_enemyMaxHealth;
            float percent = multPerc *_enemyCurrentHealth/100;
            hpBarMaterial.SetFloat("_Percentage", percent);
        }

        void Death()
        {
            Destroy(mainGo, 1f);
            Instantiate(coin, transform.position + new Vector3(0, 1, 0), coin.transform.rotation);
            StartCoroutine(SpawnPSBubble());
            if(playerStats.isVamp)
            {
                int chanceToHeal = Random.Range(0, 10);
                if(chanceToHeal == 3)
                {
                    playerHealth.Heal(playerStats.vampHealAmmount);
                }
            }
        }

        IEnumerator SpawnPSBubble()
        {
           yield return new WaitForSeconds(0.95f);
           var ps =  Instantiate(psEnemeDeath, transform.position, transform.rotation);
           var sh = ps.shape;
           sh.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
           sh.skinnedMeshRenderer = skinnedMeshRenderer;
        }
    }

}
