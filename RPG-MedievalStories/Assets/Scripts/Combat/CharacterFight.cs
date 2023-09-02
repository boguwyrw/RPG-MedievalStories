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
            if (targetTransform != null)
            {
                bool isInRange = Vector3.Distance(transform.position, targetTransform.position) < weaponRange;
                if (!isInRange)
                {
                    characterMovement.MoveTo(targetTransform.position);
                }
                else
                {
                    characterMovement.StopInFront();
                }
            }
        }

        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log("MAM CIE " + combatTarget.name);
            targetTransform = combatTarget.transform;
        }
    }
}

