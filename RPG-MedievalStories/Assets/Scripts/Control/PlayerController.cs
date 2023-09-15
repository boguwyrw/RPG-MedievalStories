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
        [SerializeField] private LayerMask enemyLayerMask;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (MoveToTarget()) return;
                MoveToPoint();
            }
        }

        private void MoveToPoint()
        {
            RaycastHit raycastHit;
            bool hasHit = Physics.Raycast(GetRayPoint(), out raycastHit);

            if (hasHit)
            {
                characterMovement.StartMoveAction(raycastHit.point);
            }
        }

        private bool MoveToTarget()
        {
            RaycastHit[] raycastHits = Physics.RaycastAll(GetRayPoint(), Mathf.Infinity, enemyLayerMask);
            foreach (RaycastHit rayHit in raycastHits)
            {
                CombatTarget combatTarget = rayHit.transform.GetComponent<CombatTarget>();

                if (combatTarget == null) continue;

                if (!characterFight.CanAttack(combatTarget.gameObject)) continue;

                characterFight.Attack(combatTarget.gameObject);

                return true;
            }

            return false;
        }

        private Ray GetRayPoint()
        {
            return mainCamera.ScreenPointToRay(Input.mousePosition);
        }

        
    }
}
