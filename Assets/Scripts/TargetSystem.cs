using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class TargetSystem : MonoBehaviour
    {
        public int enemyLayer = 8;

        [SerializeField] Texture2D aim;
        [SerializeField] float aimSize = 50;

        public GameObject currentTarget { get; private set; }
        private Collider[] _enemyColliders = new Collider[0];


        void PlayerRotate()
        {
            if (currentTarget)
            {
                Vector3 lookPos = currentTarget.transform.position - ArenaBootstrapper.Instance.player.transform.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);
                ArenaBootstrapper.Instance.player.transform.rotation = Quaternion.Lerp(ArenaBootstrapper.Instance.player.transform.rotation, rotation, 10 * Time.deltaTime);
            }
        }

        void OnGUI()
        {
            if (currentTarget)
            {
                Vector2 tmp = new Vector2(Camera.main.WorldToScreenPoint(currentTarget.transform.position).x,
                                          Screen.height - Camera.main.WorldToScreenPoint(currentTarget.transform.position).y);

                Vector2 offset = new Vector2(-aimSize / 2, -aimSize / 2);
                GUI.DrawTexture(new Rect(tmp.x + offset.x, tmp.y + offset.y, aimSize, aimSize), aim);
            }
        }

        void FixedUpdate()
        {
            GetTarget();

            if (_enemyColliders.Length >= 1)
            {
                    NearTarget();                    
            }

            else if (_enemyColliders.Length == 0)
            {
                currentTarget = null;
                if (_enemyColliders.Length == 0)
                {
                    ArenaBootstrapper.Instance.isArenaCleaned = true;
                }
            }
            else
            {
                currentTarget = null;
            }
            PlayerRotate();
        }

        void NearTarget()
        {
            if (_enemyColliders.Length > 0)
            {
                currentTarget = _enemyColliders[0].gameObject;
                foreach (var collider in _enemyColliders)
                {
                    if (Vector3.Distance(ArenaBootstrapper.Instance.player.transform.position, collider.gameObject.transform.position) < Vector3.Distance(ArenaBootstrapper.Instance.player.transform.position, currentTarget.gameObject.transform.position))
                    {
                        currentTarget = collider.gameObject;
                    }
                }
            }
            else { currentTarget = null; }
        }

        void GetTarget()
        {
            _enemyColliders = new Collider[0];
            _enemyColliders = Physics.OverlapSphere(ArenaBootstrapper.Instance.player.transform.position,1000, 1 << enemyLayer);

            if (currentTarget) return;
        }
    }   
}