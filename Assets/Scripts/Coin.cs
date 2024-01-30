using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] int value;
        Magnet magnet;
        private void OnTriggerEnter(Collider coll)
        {
            magnet = FindObjectOfType<Magnet>();
            if(magnet.isArenaCleaned)
            {
                coll.gameObject.GetComponent<ICoinable>()?.AddMoney(value);
                Destroy(gameObject);
            }
        }
    }
}