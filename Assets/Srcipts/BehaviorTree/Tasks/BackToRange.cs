using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine;

[TaskDescription("获取进入目标包围盒的最近切入点")]
public class BackToRange : Action
{
    [Tooltip("目标包围盒")]
    public SharedCollider collider;
    [Tooltip("进入目标包围盒的最近切入点")]
    public SharedVector3 returnPos;

    public override TaskStatus OnUpdate()
    {
        returnPos.Value = collider.Value.bounds.ClosestPoint(transform.position);
        return TaskStatus.Success;
    }
}
