using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehavior : MonoBehaviour
{
        public Transform followTarget, pole;  
    Vector3 currentPosition, previousPos, currentVel;
    public float moveSpeed, turnSpeed, nodeDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            Vector3 curVel = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, followTarget.position + -pole.right * nodeDistance, ref curVel, moveSpeed);//+ -transform.right * nodeDistance
    }

     public void EnterFollowLine(Transform followTarget, float moveSpeed, float turnSpeed, float nodeDistance, Transform pole)
    {
        //2
        this.followTarget = followTarget;
        this.moveSpeed = moveSpeed;
        this.turnSpeed = turnSpeed;
        this.nodeDistance = nodeDistance;
        this.pole = pole;
    }
}
