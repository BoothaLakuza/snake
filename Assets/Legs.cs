using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    float rotationAngle = 0f;
    public float speed = 1f, ymultp, xmultp = 3f;
    public Transform lLeg;
    public Transform rLeg;

    Vector2[] startPos = new Vector2[2];
    public float rayDist = 2f;
    //LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        lLeg = transform.GetChild(0);
        rLeg = transform.GetChild(1);
        
        startPos[0] = lLeg.localPosition;
        startPos[1] = rLeg.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        rotationAngle = (rotationAngle < 0f) ? rotationAngle + 360f : (rotationAngle > 360f ? rotationAngle - 360f : rotationAngle);

        if (Input.GetKey(KeyCode.G))
        {
            rotationAngle += speed;
        }
         Vector2 anchor = Quaternion.Euler(0f, 0f, rotationAngle) * Vector2.right * 0.25f;
        // Vector2 anchor = Quaternion.Euler(0f, 0f, rotationAngle) * Vector2.right * 0.25f;
        lLeg.localPosition = new Vector2(xmultp * anchor.x, ymultp * anchor.y);
        // LFoot.connectedAnchor = new Vector2(0f, -0.25f);
          anchor = -anchor;
        rLeg.localPosition = new Vector2(xmultp * anchor.x, ymultp * anchor.y);
        //rLeg.localPosition = new Vector2(0f, -0.25f);

        DroppingRaycast();
    }
    void DroppingRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(lLeg.position, Vector2.down, rayDist, LayerMask.GetMask("Ground"));
        RaycastHit2D hit1 = Physics2D.Raycast(rLeg.position, Vector2.down, rayDist, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            lLeg.position = hit.point;
        }
        else
        {
            lLeg.localPosition = startPos[0];
        }
        if (hit1.collider != null)
        {
            rLeg.position = hit1.point;
        }
        else
        {
            rLeg.localPosition = startPos[1];
        }
    }
}
