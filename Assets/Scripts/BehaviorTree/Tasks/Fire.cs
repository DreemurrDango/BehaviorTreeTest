using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class Fire : Action
{
    [Tooltip("�ӵ�Ԥ����")]
    public SharedGameObject bulletPrefab;
    [Tooltip("�����ӵ���Ŀ��")]
    public SharedGameObject target;
    [Tooltip("����λ��")]
    public SharedTransform fireT;

    public override TaskStatus OnUpdate()
    {
        if(bulletPrefab == null || target == null || fireT == null)
            return TaskStatus.Failure;
        Bullet bullet = Object.Instantiate(bulletPrefab.Value, fireT.Value).GetComponent<Bullet>();
        if(bullet == null)return TaskStatus.Failure;
        bullet.Init((target.Value.transform.position - transform.position).normalized);
        return TaskStatus.Success;
    }
}
