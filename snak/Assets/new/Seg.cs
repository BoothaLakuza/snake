using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seg : MonoBehaviour
{
    public List<Transform> bodyParts;
    public List<GameObject> childrenBody;

    [Header("Node Parameters")]
    public float colliderRadius;
    public float distanceBtwn;
    public float frc;

    [Header("Child Parameters")]
    public float factor;
    public float amplitude;


    private void Awake()
    {

        Vector3 bodyStartPoint = bodyParts[0].transform.position;

        for (int i = 0; i < bodyParts.Count; i++)
        {
            bodyStartPoint.x -= distanceBtwn;
            bodyParts[i].transform.position = bodyStartPoint; // sort all parts in awake apart of each other


            //Set Rigidbody2D to bodyParts
            var childRigidbody = bodyParts[i].gameObject.AddComponent<Rigidbody2D>();
            childRigidbody.freezeRotation = true;
            childRigidbody.mass = 0.35f;
            //childRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;

            bodyParts[0].gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            //bodyParts[0].gameObject.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;

            //Get childrens of bodyParts with tag "Body" add them to List<> && apply circleCollider2D to them
            foreach (Transform g in bodyParts[i].GetComponentsInChildren<Transform>())
            {
                if (g.tag == "body")
                {
                    childrenBody.Add(g.gameObject);
                }
            }

            childrenBody[i].AddComponent<CircleCollider2D>();

        }

        //Add DistanceJoints2D to bodyParts from the last element in List<>
        for (int q = 0; q < bodyParts.Count - 1; q++)
        {
            var joint = bodyParts[q + 1].gameObject.AddComponent<DistanceJoint2D>();
            joint.connectedBody = bodyParts[q].gameObject.GetComponent<Rigidbody2D>();
            joint.autoConfigureDistance = false;
            joint.maxDistanceOnly = true;
            joint.distance = distanceBtwn;
        }
        var mvScript = bodyParts[0].gameObject.AddComponent<move>();
        mvScript.force = frc;
    }

    void Start()
    {

    }

    void Update()
    {
        SinMovement();
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        AddComponents();
       // }
    }

    void SinMovement()
    {
        //Apply SnakeLike animation to childBody's
        for (int i = 1; i < childrenBody.Count; i++)
        {
            Vector3 position = childrenBody[i].transform.localPosition;
            //position.y = Mathf.Sin(Time.time + i  *factor) * amplitude ;
            position.y = Mathf.PingPong(Time.time + i * factor, amplitude);
            childrenBody[i].transform.localPosition = position;
        }
    }

    void AddComponents()
    {
        for (int i = 1; i < bodyParts.Count; i++)
        {  
                var childRigidbody = bodyParts[i].gameObject.GetComponent<Rigidbody2D>();
                childRigidbody.freezeRotation = true;
                childRigidbody.mass = 0.35f;
                //childRigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
            for (int s = 0; s < childrenBody.Count; s++)
            {
                if (childrenBody[s].gameObject.GetComponent<Collider2D>() == null)
                {
                    childrenBody[s].AddComponent<CircleCollider2D>();
                }
            }

        for (int q = 0; q < bodyParts.Count - 1; q++)
        {
            if (bodyParts[q + 1].gameObject.GetComponent<DistanceJoint2D>() != null)
            {
                var joint = bodyParts[q + 1].gameObject.GetComponent<DistanceJoint2D>();
                joint.connectedBody = bodyParts[q].gameObject.GetComponent<Rigidbody2D>();
                joint.autoConfigureDistance = false;
                joint.maxDistanceOnly = true;
                joint.distance = distanceBtwn;
            }
        }
    }
}
