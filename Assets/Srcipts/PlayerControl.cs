using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;  // 移动速度
    public float rotateSpeed = 100f;  // 旋转速度

    void Update()
    {
        // 获取WSAD输入
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // 根据输入移动胶囊体
        transform.Translate(Vector3.forward * -1 * moveVertical * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * moveHorizontal * rotateSpeed * Time.deltaTime);
    }
}