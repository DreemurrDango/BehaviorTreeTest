using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    /// <summary>
    /// 被选中时动作
    /// </summary>
    public void OnSelected()
    {
        beSelectedTip.SetActive(true);
    }

    /// <summary>
    /// 被取消选中时动作
    /// </summary>
    public void OnDeSelected()
    {
        beSelectedTip.SetActive(false);
    }
}
