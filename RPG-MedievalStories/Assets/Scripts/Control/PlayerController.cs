using rpg.combat;
using rpg.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private CharacterFight characterFight;

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
                MoveToTarget();
            }
        }

        private void MoveToPoint()
        {
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(GetRayPoint(), out raycastHit);

            if (hasHit)
            {
                characterMovement.MoveTo(raycastHit.point);
            }
        }

        private void MoveToTarget()
        {
            RaycastHit[] raycastHits = Physics.RaycastAll(GetRayPoint());
            foreach (RaycastHit rayHit in raycastHits)
            {
                CombatTarget combatTarget = rayHit.transform.GetComponent<CombatTarget>();

                if (combatTarget == null) continue;

                characterFight.Attack(combatTarget);
            }
        }

        private Ray GetRayPoint()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        
    }
}
