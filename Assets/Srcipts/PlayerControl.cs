using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;  // �ƶ��ٶ�
    public float rotateSpeed = 100f;  // ��ת�ٶ�

    void Update()
    {
        // ��ȡWSAD����
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // ���������ƶ�������
        transform.Translate(Vector3.forward * -1 * moveVertical * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * moveHorizontal * rotateSpeed * Time.deltaTime);
    }
}