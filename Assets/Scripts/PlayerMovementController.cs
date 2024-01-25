using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterController _characterController;
        [SerializeField] float _speed;
        public bool isMoving { get; private set; } 

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
            _characterController = GetComponent<CharacterController>();
        }
        void Update()
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) 
            {
                MoveLogic();
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

        private void MoveLogic()
        {
            _characterController.Move(movementVector * Time.deltaTime * _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "UpperCameraBorder" || other.name == "DownCameraBorder")
            {
                SceneAdministrator.Instance.mainCamera.GetComponent<CameraMovement>().enabled = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "UpperCameraBorder" || other.name == "DownCameraBorder")
            {
                SceneAdministrator.Instance.mainCamera.GetComponent<CameraMovement>().enabled = true;
            }
        }
    }
}
