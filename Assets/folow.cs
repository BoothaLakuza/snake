using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folow : MonoBehaviour
{
    AnimationCurve crv;
    public Transform mover, moverScnd;
    public Transform targetR, targetL;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //curspeed *= 2;
        //    transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
        //}
        mover.position = targetR.position;
        moverScnd.position = targetL.position;
    }
}
