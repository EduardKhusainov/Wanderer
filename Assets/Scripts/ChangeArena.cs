using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Wanderer {

    public class ChangeArena : MonoBehaviour
    {
        private bool _canUploadNewScene = false;
        private Collider[] _arenas;
        private int arenaNum = 0;
        [SerializeField] LayerMask _arenaLayer;
        [SerializeField] GameObject[] maps;

        private void Start()
        {
            _arenas = Physics.OverlapSphere(ArenaBootstrapper.Instance.player.transform.position, 1000, _arenaLayer);
        }
        private void Update()
        {
            if(ArenaBootstrapper.Instance.isArenaCleaned)
            {
                ArenaBootstrapper.Instance.isArenaCleaned = false;
                StartCoroutine(ArenaUpload());
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == ArenaBootstrapper.Instance.player && _canUploadNewScene) 
            {
                ArenaBootstrapper.Instance.isArenaCleaned = false;
            }
        }

        IEnumerator ArenaUpload()
        {
            yield return new WaitForSeconds(5f);
            _canUploadNewScene = true; 
        }
    }
}