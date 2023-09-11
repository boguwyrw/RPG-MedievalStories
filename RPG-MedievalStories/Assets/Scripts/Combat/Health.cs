using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private int maxHealth = 50;
        
        private int currentHealth = 0;

        private bool isDead = false;

        public bool IsDead { get { return isDead; } }

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            if (currentHealth == 0)
            {
                CharacterDie();
            }
        }

        private void CharacterDie()
        {
            if (isDead) return;

            isDead = true;
            animator.SetTrigger("Die");
        }
    }
}

