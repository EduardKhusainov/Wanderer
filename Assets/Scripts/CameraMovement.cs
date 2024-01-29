using UnityEngine;

namespace Wanderer
{
    public class CameraMovement : MonoBehaviour
    {
        public float cameraZOffset;
        private void LateUpdate()
        {
            if (ArenaBootstrapper.Instance.player == null)
                return;

            Vector3 p = ArenaBootstrapper.Instance.player.transform.position;
            p.z -= cameraZOffset;
            p.x = transform.position.x;
            p.y = transform.position.y;
            transform.position = p;
        }
    }
}
