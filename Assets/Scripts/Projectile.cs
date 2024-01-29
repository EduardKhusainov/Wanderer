using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace Wandere {
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _damage;
        public bool isHit;

        public void Update()
        {
            RaycastHits();
            Destroy(gameObject, 5f);
        }

        public void RaycastHits()
        {
            RaycastHit hit;


            if (Physics.SphereCast(transform.position, 0.5f, Vector3.forward, out hit, 0.5f, 1<<8) && !isHit)
            {
                isHit = true;
                hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                Destroy(gameObject);
            }
            if (Physics.SphereCast(transform.position, 0.5f, Vector3.left, out hit, 0.5f, 1<<8) && !isHit)
            {
                isHit = true;
                hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                Destroy(gameObject);
            }
            if (Physics.SphereCast(transform.position, 0.5f, Vector3.right, out hit, 0.5f, 1<<8) && !isHit)
            {
                isHit = true;
                hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                Destroy(gameObject);
            }
            if(Physics.SphereCast(transform.position, 0.5f, Vector3.down, out hit, 0.5f, 1<<8) && !isHit)
            {
                isHit = true;
                hit.collider.GetComponent<IDamagable>()?.TakeDamage(_damage);
                Destroy(gameObject);
            }
        
        }
    }
}