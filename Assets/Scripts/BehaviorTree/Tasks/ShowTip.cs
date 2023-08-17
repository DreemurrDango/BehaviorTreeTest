using UnityEngine;
using TMPro;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

[TaskCategory("UI")]
[TaskDescription("��UI�ı��������ʾ����")]
public class ShowTip : Action
{
    [Tooltip("Ŀ���ı����")]
    public TMP_Text target;
    [Tooltip("Ҫ��ʾ������")]
    public string tip;

    public override TaskStatus OnUpdate()
    {
        if (target == null)return TaskStatus.Failure;
        target.text = tip;
        if(tip == "")target.gameObject.SetActive(false);
        else target.gameObject.SetActive(true);
        return TaskStatus.Success;
    }
}
