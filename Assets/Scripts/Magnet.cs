using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class Magnet : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] LayerMask _layerMask;

        public bool isArenaCleaned;
        void Update()
        {
            if(isArenaCleaned)
            {

                Collider[] magneticItems = Physics.OverlapSphere(transform.position, 1000, _layerMask);


                foreach (var coll in magneticItems)
                {
                    coll.gameObject.transform.position = Vector3.MoveTowards(coll.gameObject.transform.position, ArenaBootstrapper.Instance.player.transform.position, _speed * Time.deltaTime);
                }
            }
        }
    }   
}
