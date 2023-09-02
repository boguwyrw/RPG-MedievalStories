using rpg.combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpg.movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent meshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterFight characterFight;

        private void Start()
        {
            
        }

        private void Update()
        {
            AnimatorUpdate();
        }

        public void StartMoveAction(Vector3 destinationPoint)
        {
            characterFight.CancelTarget();
            MoveTo(destinationPoint);
        }

        public void MoveTo(Vector3 destinationPoint)
        {
            meshAgent.isStopped = false;
            meshAgent.destination = destinationPoint;
        }

        public void StopInFront()
        {
            meshAgent.isStopped = true;
        }

        private void AnimatorUpdate()
        {
            Vector3 velocity = meshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            animator.SetFloat("ForwardSpeed", speed);
        }
    }
}
