using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;


    public class MoveToObject : EnemyAction
    {
        public float Speed;
        public float KeepDistance;
        public SharedTransform Target;
        public bool trackPosY;

        public override TaskStatus OnUpdate()
        {
            if (Vector3.SqrMagnitude(transform.position - Target.Value.position) < KeepDistance)
            {
                return TaskStatus.Success;
            }
            // Vector3 tartgetPos = new Vector3(Target.Value.position.x, transform.position.y, Target.Value.position.z);
            //
            // transform.LookAt(tartgetPos);
            //
            // transform.position = Vector3.MoveTowards(transform.position, Target.Value.position, Speed * Time.deltaTime);
            NavMeshAgent.SetDestination(Target.Value.position);
            return TaskStatus.Running;
        }
    }
