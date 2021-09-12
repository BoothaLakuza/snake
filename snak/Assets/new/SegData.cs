using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegData : MonoBehaviour
{
    public Transform followTarget, pole;
    Vector3 currentPosition, previousPos, currentVel;
    public float moveSpeed, turnSpeed, nodeDistance;
    // Start is called before the first frame update
    void Start()
    {

        var joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.connectedBody = followTarget.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterFollowLine(Transform followTarget)
    {
        //2
        this.followTarget = followTarget;
 
    }
}
