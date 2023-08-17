using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class Fire : Action
{
    [Tooltip("子弹预制体")]
    public SharedGameObject bulletPrefab;
    [Tooltip("发射子弹的目标")]
    public SharedGameObject target;
    [Tooltip("发射位置")]
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
