using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer {
    public class MagicWand : MonoBehaviour
    {
        TargetSystem _targetSystem;

        [SerializeField] GameObject _spawnPoint;
        [SerializeField] GameObject _spell;
        [SerializeField] float _reloadTime;
        private CharacterController _characterController;
        private bool _isShooted;
        private PlayerController _playerController;

        void Start()
        {
            _targetSystem = GetComponent<TargetSystem>();
            _characterController = GetComponent<CharacterController>();
            _playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            if (!SceneAdministrator.Instance.isArenaCleaned)
            {
                Shoot();
            }
        }
        public void Shoot()
        {
            if (!_playerController.isMoving && !_isShooted)
            {
                _isShooted = true;
                StartCoroutine(Reload(_reloadTime));
            }
            else if (_playerController.isMoving && _isShooted)
            {
                StopAllCoroutines();
                _isShooted = false;
            }
        }

        void CastSpell()
        {
            if (_targetSystem.currentTarget != null)
            {
                GameObject fireball = Instantiate(_spell, _spawnPoint.transform.position, Quaternion.identity);
                Rigidbody fireballRb = fireball.GetComponent<Rigidbody>();
                fireballRb.AddForce((_targetSystem.currentTarget.transform.position - _spawnPoint.transform.position) * 3, ForceMode.Impulse);
            }
        }

        IEnumerator Reload(float reloadTime)
        {
            yield return new WaitForSeconds(reloadTime);
            CastSpell();
            _isShooted = false;
        }
    }
}