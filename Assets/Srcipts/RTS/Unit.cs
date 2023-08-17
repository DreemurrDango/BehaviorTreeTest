using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����RTS��λ�Ļ��࣬����ʵ��ѡ�й���
/// </summary>
public class Unit : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�Ƿ�ɱ�ѡ��")]
    private bool selectable = false;
    [SerializeField]
    [Tooltip("�Ƿ��ͨ����ѡ��ѡ��")]
    private bool rangeSelectable = false;
    [SerializeField]
    [Tooltip("������Ӫ��0��ʾ���")]
    private int belongGroup;
    [SerializeField]
    [Tooltip("��ѡ��ʱ��ʾ�ı��")]
    private GameObject beSelectedTip;

    /// <summary>
    /// ��ǰ�Ƿ��Ƿ�ѡ��
    /// </summary>
    private bool beSelected = false;
    /// <summary>
    /// �Ƿ�ɱ�ѡ��
    /// </summary>
    public bool Selectable => selectable;
    /// <summary>
    /// ������Ӫ
    /// </summary>
    public int BelongGroup => belongGroup;
    /// <summary>
    /// �Ƿ�ɱ���ѡ��
    /// </summary>
    public bool RangeSelectable => selectable && rangeSelectable;

    /// <summary>
    /// ��ѡ��ʱ����
    /// </summary>
    public void OnSelected()
    {
        beSelectedTip.SetActive(true);
    }

    /// <summary>
    /// ��ȡ��ѡ��ʱ����
    /// </summary>
    public void OnDeSelected()
    {
        beSelectedTip.SetActive(false);
    }
}
