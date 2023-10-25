using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Game._Scripts.BTScripts
{
    public class MoveTo : EnemyAction
    {
        public float speed;
        public SharedTransform Target;

        public override TaskStatus OnUpdate()
        {
            if (Vector3.SqrMagnitude(transform.position - Target.Value.position) < 0.1f)
            {
                return TaskStatus.Success;
            }
            // Vector3 tartgetPos = new Vector3(Target.Value.position.x, transform.position.y, Target.Value.position.z);
            // transform.LookAt(tartgetPos);
            // transform.position = Vector3.MoveTowards(transform.position, Target.Value.position, speed * Time.deltaTime);
            NavMeshAgent.SetDestination(Target.Value.position);

            return TaskStatus.Running;
        }
    }
}