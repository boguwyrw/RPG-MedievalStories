using rpg.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MoveToTarget();
            }
        }

        private void MoveToTarget()
        {
            Ray targetRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(targetRay, out raycastHit);

            if (hasHit)
            {
                characterMovement.MoveTo(raycastHit.point);
            }
        }
    }
}
