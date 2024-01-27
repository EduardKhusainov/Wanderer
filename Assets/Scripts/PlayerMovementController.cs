using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Wanderer
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;
        [SerializeField] float _speed;
        public bool isMoving { get; private set; } 
        public Animator animator;
        public AnimatorController animWalk;
        public AnimatorController animIdle;
        public AnimatorController animAttack;
        public float rotationSpeed;
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
                MoveLogic();
                isMoving = true;
                animator.runtimeAnimatorController = animWalk;
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
