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

        private void Start()
        {
            _enemyCurrentHealth = _enemyMaxHealth;
            hpBarMaterial = go.GetComponent<Renderer>().material;
        }
        public void TakeDamage(float value)
        {
            _enemyCurrentHealth -= value;
            float multPerc = 100/_enemyMaxHealth;
            float percent = multPerc *_enemyCurrentHealth/100;
            hpBarMaterial.SetFloat("_Percentage", percent);
            if (_enemyCurrentHealth == 0)
            {
                Death();
            }
            if(_enemyCurrentHealth < 0)
            {
                _enemyCurrentHealth = 0;
                Death();
            }
        }

        void Death()
        {
            Destroy(gameObject, 1f);
            Instantiate(coin, transform.position + new Vector3(0, 1, 0), coin.transform.rotation);
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
