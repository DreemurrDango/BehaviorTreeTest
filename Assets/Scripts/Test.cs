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
                Debug.Log("目标进入" + gameObject.name + "的范围");
                inRange = true;
            }
        }
        else if(inRange)
        {
            Debug.Log("目标离开" + gameObject.name + "的范围");
            inRange = false;
        }
    }
}
