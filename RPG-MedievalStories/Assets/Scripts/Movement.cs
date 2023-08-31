using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent meshAgent;
    [SerializeField] private Animator animator;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToTarget();
        }
        AnimatorUpdate();
    }

    private void MoveToTarget()
    {
        Ray targetRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        bool hasHit = Physics.Raycast(targetRay, out raycastHit);

        if (hasHit)
        {
            meshAgent.destination = raycastHit.point;
        }
    }

    private void AnimatorUpdate()
    {
        Vector3 velocity = meshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("ForwardSpeed", speed);
    }
}
