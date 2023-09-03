using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rpg.core
{
    public class ActionScheduler : MonoBehaviour
    {
        private IAction currentAction;

        private void Start()
        {

        }

        private void Update()
        {

        }

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;

            if (currentAction != null)
            {
                currentAction.CancelAction();
            }

            currentAction = action;
        }
    }
}
