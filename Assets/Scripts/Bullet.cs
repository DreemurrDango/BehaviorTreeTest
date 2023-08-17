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
        //�ӵ�����ָ��������ָ���ٶ��ƶ�
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("������������ң�");
        //�ӵ���ײ����������ʱ�����ӵ�
        Destroy(gameObject);
    }
}