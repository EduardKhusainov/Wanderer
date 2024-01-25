using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] float damage; 
        private void OnTriggerEnter(Collider coll)
        {
            coll.gameObject.GetComponent<IDamagable>()?.TakeDamage(damage);
        }
    }
}
