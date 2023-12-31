using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - player.position;
        }

        private void LateUpdate()
        {
            transform.position = player.position + offset;
        }
    }
}
