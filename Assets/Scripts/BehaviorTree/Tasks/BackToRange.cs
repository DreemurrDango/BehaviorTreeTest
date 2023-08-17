using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;
using UnityEngine;

[TaskDescription("��ȡ����Ŀ���Χ�е���������")]
public class BackToRange : Action
{
    [Tooltip("Ŀ���Χ��")]
    public SharedCollider collider;
    [Tooltip("����Ŀ���Χ�е���������")]
    public SharedVector3 returnPos;

    public override TaskStatus OnUpdate()
    {
        returnPos.Value = collider.Value.bounds.ClosestPoint(transform.position);
        return TaskStatus.Success;
    }
}
