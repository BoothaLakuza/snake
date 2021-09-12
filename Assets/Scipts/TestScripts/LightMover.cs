using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMover : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float speed;
    bool isArrived;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target1.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == target1.position)
        {
            isArrived = false;
        }
        else if (transform.position == target2.position)
        {
            isArrived = true;
        }


        transform.position = Vector3.Lerp(target1.position, target2.position, Mathf.PingPong(Time.time / speed, 1));
    }
}
