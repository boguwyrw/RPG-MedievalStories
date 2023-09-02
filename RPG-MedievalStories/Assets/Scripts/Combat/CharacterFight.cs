using rpg.movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.combat
{
    public class CharacterFight : MonoBehaviour
    {
        [SerializeField] private CharacterMovement characterMovement;

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
                characterMovement.StopInFront();
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, targetTransform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log("MAM CIE " + combatTarget.name);
            targetTransform = combatTarget.transform;
        }

        public void CancelTarget()
        {
            targetTransform = null;
        }
    }
}

