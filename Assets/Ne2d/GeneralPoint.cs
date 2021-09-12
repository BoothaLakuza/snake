using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPoint : MonoBehaviour
{
    public float distanceBtwn;


    public float RigidbodyMass = 1f;
    public float ColliderRadius = 0.1f;
    public float JointSpring = 0.1f;
    public float JointDamper = 5f;
    public Vector3 RotationOffset;
    public Vector3 PositionOffset;
 


    public List<Transform> CopySource;
    protected List<Transform> CopyDestination;
    protected static GameObject RigidBodyContainer;

    void Awake()
    {
        if (RigidBodyContainer == null)
        {
            RigidBodyContainer = new GameObject("RopeRigidbodyContainer");
        }

        CopySource = new List<Transform>();
        CopyDestination = new List<Transform>();

        //add children
        AddChildren(transform);
    }

    private void AddChildren(Transform parent)
    {


        for (int i = 0; i < parent.childCount; i++)
        {
            var child = parent.GetChild(i);
           //Debug.Log(child);
            var representative = new GameObject(child.gameObject.name);
            representative.transform.parent = RigidBodyContainer.transform; 
            //rigidbody
            var childRigidbody = representative.gameObject.AddComponent<Rigidbody2D>();
            //childRigidbody.useGravity = true;
            

            //collider
            var collider = representative.gameObject.AddComponent<CircleCollider2D>();
            //collider.z = Vector3.zero;
            collider.radius = ColliderRadius;

            //DistanceJoint
            //var joint = representative.gameObject.AddComponent<DistanceJoint2D>();
            for (int q = 1; q < CopySource.Count ; q++)
            {
                var hinje = representative.gameObject.AddComponent<HingeJoint2D>();
                //joint.connectedBody = CopySource[q].gameObject.GetComponent<Rigidbody2D>();
                hinje.connectedBody = CopySource[q].gameObject.GetComponent<Rigidbody2D>();
                hinje.autoConfigureConnectedAnchor = true;
            }
            //joint.connectedBody = representative.gameObject.GetComponent<Rigidbody2D>();
            //joint.DetermineDistanceOnStart = true;
            //joint.Spring = JointSpring;
            //joint. = JointDamper;
            //joint.DetermineDistanceOnStart = false;
            //joint.autoConfigureDistance = false;
            //joint.distance = /*Vector3.Distance(parent.position, child.position)*/ distanceBtwn;

            //add copy source
            CopySource.Add(representative.transform);
            CopyDestination.Add(child);

            AddChildren(child);

           // Debug.Log();
        }
    
    }

    public void Update()
    {
        for (int i = 0; i < CopySource.Count; i++)
        {
       //     CopyDestination[i].position = CopySource[i].position + PositionOffset;
      //      CopyDestination[i].rotation = CopySource[i].rotation ;
        }
        
    }
}
