using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

[TaskName("是否在包围盒范围内")]
public class BeInRange : Conditional
{
    [Tooltip("要判断的目标形变位置")]
    public SharedTransform aimT;
    [Tooltip("要检查的范围包围盒")]
    public SharedCollider aimBound;
    [Tooltip("当在包围盒之外时，返回的最近的切入点")]
    public SharedVector3 closePos;

    public override TaskStatus OnUpdate()
    {
        if (aimT == null || aimBound == null)return TaskStatus.Failure;
        if (aimBound.Value.bounds.Contains(aimT.Value.position)) return TaskStatus.Success;
        else
        {
            closePos.Value = aimBound.Value.bounds.ClosestPoint(aimT.Value.position);
            return TaskStatus.Failure;
        }
    }
}
