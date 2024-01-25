using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] int value;
        private void OnTriggerEnter(Collider coll)
        {
            coll.gameObject.GetComponent<ICoinable>()?.AddMoney(value);
            Destroy(gameObject);
        }
    }
}