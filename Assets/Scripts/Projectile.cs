using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Wanderer;

namespace Wandere {
    public class Projectile : MonoBehaviour
    {
        public float _damage;
        
        public bool isHit;
        public float speed;
        PlayerStats playerStats;
        PlayerHealth playerHealth;
        private int Layer = 3;

        private void Start() 
        {
            _damage = FindObjectOfType<PlayerStats>().playerDamage;
            playerStats = FindObjectOfType<PlayerStats>();
            playerHealth = FindObjectOfType<PlayerHealth>();
            speed = playerStats.bulletSpeed;

        }
        public void Update()
        {
            RaycastHits();
            //Destroy(gameObject, 5f);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
        }

        

        public void RaycastHits()
        {
            RaycastHit hit;


            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.1f, 1<<Layer) && !isHit)
            {
                DoDamage(hit);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.1f, 1<<Layer) && !isHit)
            {
                DoDamage(hit);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 0.1f, 1<<Layer) && !isHit)
            {
               DoDamage(hit);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.1f, 1<<Layer) && !isHit)
            {
               DoDamage(hit);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 0.1f, 1<<Layer) && !isHit)
            {
               DoDamage(hit);
            }
            if(Physics.Raycast(transform.position, Vector3.forward, out hit, 0.1f, 1 << 0) && !isHit)
            {
                Destroy(gameObject);
            }
        
        }

        public void DoDamage(RaycastHit hit)
        {
            isHit = true;
            if(playerStats.isCrit)
            {
                int critCnahce = Random.Range(0, 1000);
                if(critCnahce < 100)
                {
                    _damage = playerStats.currentCoeff * playerStats.playerDamage + playerStats.playerDamage;
                    hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                    HealFromHit();
                }   
                else
                {
                    _damage = playerStats.playerDamage;
                    hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                    HealFromHit();
                }
            }
            else
            {
                _damage = playerStats.playerDamage;
                hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                HealFromHit();
            }
            Destroy(gameObject);
        }

        public void HealFromHit()
        {
            if(playerStats.isVampfromHit)
            {
                int chance = Random.Range(0, 100);
                if(chance <=10)
                {
                    float healAmmount = _damage * 0.5f;
                    playerHealth.Heal(healAmmount);
                }
            }
        }
    }
}