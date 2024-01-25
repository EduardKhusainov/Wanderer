using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class Magnet : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] LayerMask _layerMask;


        void Update()
        {
            if (SceneAdministrator.Instance.isArenaCleaned)
            {

                Collider[] magneticItems = Physics.OverlapSphere(transform.position, 1000, _layerMask);


                foreach (var coll in magneticItems)
                {
                    coll.gameObject.transform.position = Vector3.MoveTowards(coll.gameObject.transform.position, SceneAdministrator.Instance.player.transform.position, _speed * Time.deltaTime);
                }
            }
        }
    }   
}
