using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;


public class MoveToObject : EnemyAction
{
    public float Speed;
    public SharedFloat KeepDistance;
    public SharedTransform Target;
    public bool trackPosY;

    public override void OnStart()
    {
        animator.Play("Walk");
        navMeshAgent.isStopped = false;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - Target.Value.position) < 5)
        {
            return TaskStatus.Success;
        }

        // Vector3 tartgetPos = new Vector3(Target.Value.position.x, transform.position.y, Target.Value.position.z);
        //
        // transform.LookAt(tartgetPos);
        //
        // transform.position = Vector3.MoveTowards(transform.position, Target.Value.position, Speed * Time.deltaTime);
        navMeshAgent.SetDestination(Target.Value.position);
        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        navMeshAgent.isStopped = true;
    }
}