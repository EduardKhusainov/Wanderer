using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace Wandere {
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _damage;
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IDamagable>()?.TakeDamage(_damage);
            Destroy(gameObject, 0.2f);
        }

        private void OnCollisionEnter(Collision collision) 
        {
            Destroy(gameObject);
        }
    }
}