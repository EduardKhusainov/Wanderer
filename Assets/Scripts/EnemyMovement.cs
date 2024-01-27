using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Wanderer
{
    public class EnemyMovement : MonoBehaviour
    {
        NavMeshAgent agent;
        EnemyHealth enemyHealth;
        void Start()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(ArenaBootstrapper.Instance.player != null)
            {
                if(enemyHealth._enemyCurrentHealth > 0)
                {
                    agent.SetDestination(ArenaBootstrapper.Instance.player.transform.position);
                }
            }
        }
    }
}
