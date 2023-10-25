using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace Game._Scripts.BTScripts
{
    public class Attack : Action
    {
        public GameObject AttackObject;
        public float KeepTime;
        private float _startTime;

        public override void OnStart()
        {
            AttackObject.SetActive(true);
            _startTime = Time.time;
        }

        public override TaskStatus OnUpdate()
        {
            if (Time.time - _startTime < KeepTime)
                return TaskStatus.Running;

            return TaskStatus.Success;
        }

        public override void OnEnd()
        {
            AttackObject.SetActive(false);
        }
    }
}