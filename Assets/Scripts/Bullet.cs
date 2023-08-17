using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public Vector3 direction = Vector3.forward;

    public void Init(Vector3 d,float s = 0f,float t = -1)
    {
        direction = d;
        if(s != 0)speed = s;
        if(t != -1)lifeTime = t;
        transform.LookAt(direction);
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        //子弹沿着指定方向以指定速度移动
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("攻击击中了玩家！");
        //子弹碰撞到其他物体时销毁子弹
        Destroy(gameObject);
    }
}