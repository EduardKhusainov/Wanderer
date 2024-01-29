using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController _characterController;
        [SerializeField] float _speed;
        public bool isMoving { get; private set; } 
        public Animator animator;
        public RuntimeAnimatorController animWalk;
        public RuntimeAnimatorController animIdle;
        public RuntimeAnimatorController animAttack;
        public float rotationSpeed;
        public bool isTeleported;
        private Vector3 movementVector
        {
            get
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");

                return new Vector3(horizontal, 0.0f, vertical);
            }
        }
        private void Start()
        {
            _characterController = GetComponentInChildren<CharacterController>();
        }
        void Update()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) 
            {
                if(!isTeleported)
                {
                MoveLogic();
                isMoving = true;
                animator.runtimeAnimatorController = animWalk;
                }
            }
            else
            {
                isMoving = false;
                animator.runtimeAnimatorController = animIdle;
            }
        }

        private void MoveLogic()
        {
            _characterController.Move(movementVector * Time.deltaTime * _speed);

            if(movementVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementVector, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); 
            }           
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "UpperCameraBorder" || other.name == "DownCameraBorder")
            {
                ArenaBootstrapper.Instance.mainCamera.GetComponent<CameraMovement>().enabled = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "UpperCameraBorder" || other.name == "DownCameraBorder")
            {
                ArenaBootstrapper.Instance.mainCamera.GetComponent<CameraMovement>().enabled = true;
            }
        }
    }
}
