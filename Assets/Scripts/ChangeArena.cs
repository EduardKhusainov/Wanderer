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
        [SerializeField] GameObject _firstArena;
        [SerializeField] GameObject _secondArena;

        private void Start()
        {
            _arenas = Physics.OverlapSphere(SceneAdministrator.Instance.player.transform.position, 1000, _arenaLayer);
        }
        private void Update()
        {
            if (SceneAdministrator.Instance.isArenaCleaned)
            {
                StartCoroutine(ArenaUpload());
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == SceneAdministrator.Instance.player && _canUploadNewScene) 
            {
                _secondArena.SetActive(true);
                _firstArena.SetActive(false);
                SceneAdministrator.Instance.isArenaCleaned = false;
            }
        }

        IEnumerator ArenaUpload()
        {
            yield return new WaitForSeconds(5);
            _canUploadNewScene = true; 
        }
    }
}