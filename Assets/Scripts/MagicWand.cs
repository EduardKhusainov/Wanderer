using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer.NSAudio;

namespace Wanderer {
    public class MagicWand : MonoBehaviour
    {
        TargetSystem _targetSystem;

        [SerializeField] GameObject _spawnPoint;
        [SerializeField] GameObject _spell;
        [SerializeField] float _reloadTime;
        private bool _isShooted;
        private PlayerController _playerController;
        public Vector3 targetOffset;
        void Start()
        {
            _targetSystem = GetComponent<TargetSystem>();
            _playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            if (!ArenaBootstrapper.Instance.isArenaCleaned)
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
                Instantiate(_spell, _spawnPoint.transform.position, transform.rotation);
                PlayShotEffect();
            }
        }

        private void PlayShotEffect()
        {
            if(AudioSystem.Instance != null)
            {
                var audio = AudioSystem.Instance;
                var sound = audio.FindClip(CommonSounds.PlayerAttack);

                audio.PlayEffectSound(sound);
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