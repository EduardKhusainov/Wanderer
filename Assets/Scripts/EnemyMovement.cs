using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Wanderer
{
    public class EnemyMovement : MonoBehaviour
    {
        NavMeshAgent agent;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(SceneAdministrator.Instance.player != null)
            {
                agent.SetDestination(SceneAdministrator.Instance.player.transform.position);
            }
        }
    }
}
