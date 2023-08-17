using UnityEngine;
using TMPro;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using TooltipAttribute = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

[TaskCategory("UI")]
[TaskDescription("在UI文本组件上显示内容")]
public class ShowTip : Action
{
    [Tooltip("目标文本组件")]
    public TMP_Text target;
    [Tooltip("要显示的内容")]
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
