using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

[TaskName("�Ƿ��ڰ�Χ�з�Χ��")]
public class BeInRange : Conditional
{
    [Tooltip("Ҫ�жϵ�Ŀ���α�λ��")]
    public SharedTransform aimT;
    [Tooltip("Ҫ���ķ�Χ��Χ��")]
    public SharedCollider aimBound;
    [Tooltip("���ڰ�Χ��֮��ʱ�����ص�����������")]
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
