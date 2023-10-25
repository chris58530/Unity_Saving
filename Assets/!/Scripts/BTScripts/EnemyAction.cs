using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using BehaviorDesigner.Runtime;
using UnityEngine.AI;
using UnityEngine;

namespace Game._Scripts.BTScripts
{
    public class EnemyAction : Action
    {
        protected NavMeshAgent NavMeshAgent;

        public override void OnAwake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}