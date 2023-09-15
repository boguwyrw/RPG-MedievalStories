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

        private Health targetHealth;

        private float weaponRange = 1.4f;
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

            if (targetHealth != null && targetHealth.IsDead) return;

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
            transform.LookAt(targetTransform);

            if (timeSinceLastHit > timeBetweenHits)
            {
                timeSinceLastHit = 0.0f;
                TriggerHitAttack();
            }
        }

        private void TriggerHitAttack()
        {
            animator.ResetTrigger("StopHitAttack");
            animator.SetTrigger("HitAttack");
        }

        private bool GetIsInRange()
        {
            float distToEnemy = Vector3.Distance(transform.position, targetTransform.position);
            return distToEnemy < weaponRange;
        }

        private void CancelTarget()
        {
            targetTransform = null;
            targetHealth = null;
        }

        private void StopHitAttack()
        {
            animator.ResetTrigger("HitAttack");
            animator.SetTrigger("StopHitAttack");
        }

        // Animation Event
        private void Hit()
        {
            if (targetTransform == null) return;

            if (targetHealth == null)
            {
                targetHealth = targetTransform.GetComponent<Health>();
            }

            targetHealth.TakeDamage(weaponDamage);
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetHealth = combatTarget.GetComponent<Health>();
            return targetHealth != null && !targetHealth.IsDead;
        }

        public void Attack(GameObject combatTarget)
        {
            //Debug.Log("MAM CIE " + combatTarget.name);
            actionScheduler.StartAction(this);
            targetTransform = combatTarget.transform;
        }

        public void CancelAction()
        {
            StopHitAttack();
            CancelTarget();
        } 
    }
}

