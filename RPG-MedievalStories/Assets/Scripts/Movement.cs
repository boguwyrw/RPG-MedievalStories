using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent meshAgent;

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
}
