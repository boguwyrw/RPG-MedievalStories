using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 50;
        
        private int currentHealth = 0;

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
            Debug.Log(currentHealth);
        }
    }
}

