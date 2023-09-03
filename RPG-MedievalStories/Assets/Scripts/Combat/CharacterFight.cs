using rpg.core;
using rpg.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.combat
{
    public class CharacterFight : MonoBehaviour, IAction
    {
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private ActionScheduler actionScheduler;

        private Transform targetTransform;

        private float weaponRange = 2.5f;

        private void Start()
        {

        }

        private void Update()
        {
            if (targetTransform == null) return;

            if (!GetIsInRange())
            {
                characterMovement.MoveTo(targetTransform.position);         
            }
            else
            {
                characterMovement.CancelAction();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetTransform.position) < weaponRange;
        }

        private void CancelTarget()
        {
            targetTransform = null;
        }

        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log("MAM CIE " + combatTarget.name);
            actionScheduler.StartAction(this);
            targetTransform = combatTarget.transform;
        }

        public void CancelAction()
        {
            CancelTarget();
        }
    }
}

