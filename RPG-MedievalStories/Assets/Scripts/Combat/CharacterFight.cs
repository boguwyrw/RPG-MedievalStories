using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.combat
{
    public class CharacterFight : MonoBehaviour
    {
        
        private void Start()
        {

        }

        private void Update()
        {

        }

        public void Attack(CombatTarget target)
        {
            Debug.Log("MAM CIE " + target.name);
        }
    }
}

