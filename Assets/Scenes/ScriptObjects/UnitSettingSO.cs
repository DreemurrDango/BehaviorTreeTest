using UnityEngine;

[CreateAssetMenu(fileName = "UniSettingSO", menuName = "数据/单位配置", order = 1)]
public class UniSettingSO : ScriptableObject
{
    [Header("移动功能")]
    [Tooltip("存放移动目标标记的根形变")]
    public string worldMoveRootName;
    [Tooltip("移动目标预制体")]
    public GameObject aimMoveGO;
}