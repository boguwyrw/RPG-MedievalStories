using rpg.core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace rpg.movement
{
    public class CharacterMovement : MonoBehaviour, IAction
    {
        [SerializeField] private NavMeshAgent meshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private ActionScheduler actionScheduler;

        private void Start()
        {
            
        }

        private void Update()
        {
            AnimatorUpdate();
        }

        private void AnimatorUpdate()
        {
            Vector3 velocity = meshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            animator.SetFloat("ForwardSpeed", speed);
        }

        private void StopInFront()
        {
            meshAgent.isStopped = true;
        }

        public void StartMoveAction(Vector3 destinationPoint)
        {
            actionScheduler.StartAction(this);
            MoveTo(destinationPoint);
        }

        public void MoveTo(Vector3 destinationPoint)
        {
            meshAgent.isStopped = false;
            meshAgent.destination = destinationPoint;
        }

        public void CancelAction()
        {
            StopInFront();
        }
    }
}
