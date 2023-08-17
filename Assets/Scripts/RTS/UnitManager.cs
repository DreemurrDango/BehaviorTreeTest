using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单位管理：存储单位的通用配置数据
/// </summary>
public class UnitManager : Singleton<UnitManager>
{
    [Header("移动功能")]
    [Tooltip("存放移动目标标记的根形变")]
    public Transform worldMoveRootT;
    [Tooltip("移动目标预制体")]
    public GameObject aimMovePrefab;
    [Tooltip("移动路径的显示颜色")]
    public Color moveWayColor;
}
