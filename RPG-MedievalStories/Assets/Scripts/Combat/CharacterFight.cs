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
        [SerializeField] private Animator animator;

        private Transform targetTransform;

        private Health healthComponent = null;

        private float weaponRange = 1.9f;
        private float timeBetweenHits = 1.25f;
        private float timeSinceLastHit = 0.0f;

        private int weaponDamage = 5;

        private void Start()
        {

        }

        private void Update()
        {
            timeSinceLastHit += Time.deltaTime;

            if (targetTransform == null) return;

            if (!GetIsInRange())
            {
                characterMovement.MoveTo(targetTransform.position);
            }
            else
            {
                characterMovement.CancelAction();
                HitAttackBehaviour();
            }
        }

        private void HitAttackBehaviour()
        {
            if (timeSinceLastHit > timeBetweenHits)
            {
                timeSinceLastHit = 0.0f;
                animator.SetTrigger("HitAttack");
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

        // Animation Event
        private void Hit()
        {
            if (healthComponent == null)
            {
                healthComponent = targetTransform.GetComponent<Health>();
            }
            healthComponent.TakeDamage(weaponDamage);
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

