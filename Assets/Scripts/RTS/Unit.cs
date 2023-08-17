using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 所有RTS单位的基类，用于实现选中功能
/// </summary>
public class Unit : MonoBehaviour
{

    [SerializeField]
    [Tooltip("是否可被选中")]
    private bool selectable = false;
    [SerializeField]
    [Tooltip("是否可通过框选被选中")]
    private bool rangeSelectable = false;
    [SerializeField]
    [Tooltip("所属阵营，0表示玩家")]
    private int belongGroup;
    [SerializeField]
    [Tooltip("被选中时显示的标记")]
    private GameObject beSelectedTip;

    /// <summary>
    /// 当前是否是否被选中
    /// </summary>
    private bool beSelected = false;
    /// <summary>
    /// 被选中时事件
    /// </summary>
    [HideInInspector]
    public UnityEvent onSelected;
    /// <summary>
    /// 被取消选中时事件
    /// </summary>
    [HideInInspector]
    public UnityEvent onDeSelected;

    /// <summary>
    /// 当前单位是否正被选中
    /// </summary>
    public bool BeSelected => beSelected;
    /// <summary>
    /// 是否可被选中
    /// </summary>
    public bool Selectable => selectable;
    /// <summary>
    /// 所属阵营
    /// </summary>
    public int BelongGroup => belongGroup;
    /// <summary>
    /// 是否可被框选中
    /// </summary>
    public bool RangeSelectable => selectable && rangeSelectable;

    private void Awake()
    {
        beSelectedTip.SetActive(false);
    }

    /// <summary>
    /// 被选中时动作
    /// </summary>
    public void OnSelected()
    {
        beSelectedTip.SetActive(true);
        onSelected.Invoke();
    }

    /// <summary>
    /// 被取消选中时动作
    /// </summary>
    public void OnDeSelected()
    {
        beSelectedTip.SetActive(false);
        onDeSelected.Invoke();
    }
}
