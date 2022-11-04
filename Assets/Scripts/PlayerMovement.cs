using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGGeralt.Creatures
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Standard attributes")]
        [SerializeField] float rotationSpeed;
        [SerializeField] float targetThreshold = 0;

        [Header("Camera things")]
        [SerializeField] Transform camTarget;
        [SerializeField] LayerMask groundMask;

        CharacterController controller;
        Camera cam;

        //GetData
        float horizontal;
        float vertical;
        bool isLooking;

        //Directions
        Vector3 moveDirection;
        Vector3 lookDirection;

        //cameratarget
        Vector3 mousePos;

        public void Awake()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main;
        }

        public void Update()
        {
            GetInput();
        }

        public void FixedUpdate()
        {
            Move();
            UpdateTargetPosition();
        }

        public void LateUpdate()
        {
            Rotate();
        }


        void GetInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            isLooking = Input.GetMouseButton(1);

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitData, 100, groundMask))
            {
                mousePos = hitData.point;
            }
        }

        void Move()
        {
            moveDirection = new Vector3(horizontal, 0, vertical);

            if (moveDirection.magnitude > 1)
            {
                moveDirection.Normalize();
            }

            float speedPercent = 1 - (Vector3.Angle(moveDirection, lookDirection) / 360f);

            controller.Move(moveDirection * (speedPercent * Player.Instance.speed) * Time.deltaTime);
        }
        void Rotate()
        {
            if (isLooking)
            {
                targetThreshold = 5;
                lookDirection = (mousePos - transform.position);
                lookDirection.y = 0;
            }
            else
            {
                targetThreshold = 0;
                lookDirection = moveDirection;
            }

            if (lookDirection.magnitude > 0.1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDirection, Vector3.up), rotationSpeed * Time.deltaTime);
            }
        }

        void UpdateTargetPosition()
        {
            Vector3 targetPos = Vector3.ClampMagnitude(((transform.position + mousePos) / 2f) - transform.position, targetThreshold) + transform.position;
            camTarget.position = targetPos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + lookDirection * 5);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + moveDirection * 5);
        }
    }
}