using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
public class LoadNext : MonoBehaviour
{
   [SerializeField] GameObject[] maps;
   [SerializeField] PlayerController playerController;
   PlayerResetPos playerResetPos;
   int currentIndex;
   bool isMove;
    
    private void Start() 
    {
        playerController = FindObjectOfType<PlayerController>();    
        playerResetPos =  FindObjectOfType<PlayerResetPos>();
        currentIndex = 0;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            maps[currentIndex].SetActive(false);
            currentIndex++;
            maps[currentIndex].SetActive(true);
            playerController.isTeleported = true;
            playerController.transform.position = new Vector3(0,0,-15f);
            playerResetPos.isMove = true;
            this.gameObject.SetActive(false);
        } 
    }

    }
}
