using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
public class LoadNext : MonoBehaviour
{
   [SerializeField] GameObject destrotMap;
   [SerializeField] GameObject nextMap;
   [SerializeField] PlayerController playerController;
   PlayerResetPos playerResetPos;
   bool isMove;
    
    private void Start() 
    {
        playerController = FindObjectOfType<PlayerController>();    
        playerResetPos =  FindObjectOfType<PlayerResetPos>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerController.isTeleported = true;
            playerController.transform.position = new Vector3(0,0,-15f);
            destrotMap.SetActive(false);
            nextMap.SetActive(true);
            playerResetPos.isMove = true;
        } 
    }

    }

    
}
