using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer;

namespace Wanderer
{
    public class CameraMovement : MonoBehaviour
    {
        public float cameraZOffset;
        private void LateUpdate()
        {
            Vector3 p = SceneAdministrator.Instance.player.transform.position;
            p.z -= cameraZOffset;
            p.x = transform.position.x;
            p.y = transform.position.y;
            transform.position = p;
        }
    }
}
