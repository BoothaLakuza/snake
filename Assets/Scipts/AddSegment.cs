using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSegment : MonoBehaviour
{
   
    public SegmentsBehaviour sgmB;
    public NodeParent ndPrnt;
    public  Transform nodePrefab;
    Transform child;
   
    void Start()
    {
        sgmB = sgmB.GetComponent<SegmentsBehaviour>();
        ndPrnt = ndPrnt.GetComponent<NodeParent>();
    }

 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            AddSegments();
        }


     
    }
    
    void AddSegments(){
        Transform newSegment = (Instantiate(nodePrefab, ndPrnt.bodyParts[ndPrnt.bodyParts.Count - 1].position, ndPrnt.bodyParts[ndPrnt.bodyParts.Count - 1].rotation));
        newSegment.SetParent(transform);

        ndPrnt.bodyParts.Add(newSegment);
       // child =  newSegment.GetChild(0);
        //sgmB.bodyParts.Add(child);
        Debug.Log(child.position);
    }
    
    void OnDrawGizmos()
    {
       
    }
}
