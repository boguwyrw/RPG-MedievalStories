using rpg.combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private CharacterFight characterFight;
        [SerializeField] private float chaseDistance = 4.0f;

        private GameObject player = null;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if (player != null && InAttackRange() && characterFight.CanAttack(player))
            {
                characterFight.Attack(player);
            }
        }

        private bool InAttackRange()
        {
            float distToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distToPlayer < chaseDistance;
        }
    }
}