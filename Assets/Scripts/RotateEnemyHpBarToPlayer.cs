using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class RotateEnemyHpBarToPlayer : MonoBehaviour
    {
        void Update()
        {
            gameObject.transform.rotation = Quaternion.Euler(-55.08f,180, 0);
        }
    }
}
