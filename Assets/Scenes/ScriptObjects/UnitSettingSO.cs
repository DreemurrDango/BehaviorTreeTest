using UnityEngine;

[CreateAssetMenu(fileName = "UniSettingSO", menuName = "����/��λ����", order = 1)]
public class UniSettingSO : ScriptableObject
{
    [Header("�ƶ�����")]
    [Tooltip("����ƶ�Ŀ���ǵĸ��α�")]
    public string worldMoveRootName;
    [Tooltip("�ƶ�Ŀ��Ԥ����")]
    public GameObject aimMoveGO;
}