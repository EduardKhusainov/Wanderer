using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
public class LoadNext : MonoBehaviour
{
   [SerializeField] GameObject go;
   [SerializeField] GameObject map;
   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(go, new Vector3(3.94146037f,12.4308214f,-11.6465702f), go.transform.rotation);
            Destroy(map);
        } 
   }
}
}
