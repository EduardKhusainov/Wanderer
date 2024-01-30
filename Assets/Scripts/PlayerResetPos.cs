using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer 
{
public class PlayerResetPos : MonoBehaviour
    {
    public Vector3 startPos = new Vector3(0,0,-15f);
    PlayerController playerController;
    public bool isMove;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.transform.position = startPos;
    }

    private void Update() 
    {
        if(playerController.isTeleported  && playerController != null)
        {
            playerController.transform.position = startPos;
            StartCoroutine(ResetBool());
        }    
    }

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(0.1f);
        isMove = false;
        playerController.isTeleported = false;
    }
    }
}
