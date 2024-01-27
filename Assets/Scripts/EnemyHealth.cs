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
            //enemyAnimator.animator.runtimeAnimatorController = enemyAnimator.animDeath;
            Destroy(gameObject, 1f);
            Instantiate(coin, transform.position, coin.transform.rotation);
            StartCoroutine(SpawnPSBubble());
        }

        IEnumerator SpawnPSBubble()
        {
           yield return new WaitForSeconds(0.95f);
           var ps =  Instantiate(psEnemeDeath, transform.position, transform.rotation);
           var sh = ps.shape;
           sh.shapeType = ParticleSystemShapeType.SkinnedMeshRenderer;
           sh.skinnedMeshRenderer = skinnedMeshRenderer;
           Debug.Log("Spawned");
        }
    }

}
