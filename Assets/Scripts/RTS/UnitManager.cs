using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��λ�����洢��λ��ͨ����������
/// </summary>
public class UnitManager : Singleton<UnitManager>
{
    [Header("�ƶ�����")]
    [Tooltip("����ƶ�Ŀ���ǵĸ��α�")]
    public Transform worldMoveRootT;
    [Tooltip("�ƶ�Ŀ��Ԥ����")]
    public GameObject aimMovePrefab;
    [Tooltip("�ƶ�·������ʾ��ɫ")]
    public Color moveWayColor;
}
