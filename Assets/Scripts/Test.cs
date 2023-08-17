using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform aimT;

    private Collider collider;
    private bool inRange = false;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        //If the first GameObject's Bounds contains the Transform's position, output a message in the console
        if (collider.bounds.Contains(aimT.position))
        {
            if(!inRange)
            {
                Debug.Log("Ŀ�����" + gameObject.name + "�ķ�Χ");
                inRange = true;
            }
        }
        else if(inRange)
        {
            Debug.Log("Ŀ���뿪" + gameObject.name + "�ķ�Χ");
            inRange = false;
        }
    }
}
