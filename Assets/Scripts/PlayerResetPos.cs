using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
public class PlayerResetPos : MonoBehaviour
    {
    public Vector3 startPos = new Vector3(0,0,-15f);
    PlayerController playerController;
    void Start()
        {
            playerController = FindObjectOfType<PlayerController>();
            playerController.transform.position = startPos;
        }

    }
}
