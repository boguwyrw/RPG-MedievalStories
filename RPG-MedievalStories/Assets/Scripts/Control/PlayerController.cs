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
                MoveToPoint();
            }
        }

        private void MoveToPoint()
        {
            Ray rayPoint = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(rayPoint, out raycastHit);

            if (hasHit)
            {
                characterMovement.MoveTo(raycastHit.point);
            }
        }
    }
}
