using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSegments : MonoBehaviour
{
    public Seg segScrpt;
    //public NodeParent ndPrnt;
    public Transform nodePrefab;
    Transform child;
   // public int startSegCount;

    void Start()
    {
        segScrpt = segScrpt.GetComponent<Seg>();
        //ndPrnt = ndPrnt.GetComponent<NodeParent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddSegment();
        }



    }

    void AddSegment()
    {
        Transform newSegment = (Instantiate(nodePrefab, segScrpt.bodyParts[segScrpt.bodyParts.Count - 1].position, segScrpt.bodyParts[segScrpt.bodyParts.Count - 1].rotation));
        newSegment.SetParent(transform);

        segScrpt.bodyParts.Add(newSegment);
        newSegment.gameObject.AddComponent<DistanceJoint2D>();
        //newSegment.gameObject.AddComponent<Rigidbody2D>();
        newSegment.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
        child = newSegment.GetChild(0);
        segScrpt.childrenBody.Add(child.gameObject);
        //Debug.Log(child.position);
    }
}
