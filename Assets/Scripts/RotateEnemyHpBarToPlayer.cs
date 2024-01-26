using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class RotateEnemyHpBarToPlayer : MonoBehaviour
    {
        void Update()
        {
            gameObject.transform.LookAt(ArenaBootstrapper.Instance.mainCamera.transform);
        }
    }
}
