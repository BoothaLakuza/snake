using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeParent : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public Transform brainTrnsfrm;
      public float beginSize, speed, rotationSpeed, lengthBetweenNodee ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
               for (int i = 0; i<bodyParts.Count; i++)
        {
            Transform followTarget = i == 0 ? transform : bodyParts[i - 1];
            bodyParts[i].GetComponent<NodeBehavior>().EnterFollowLine(followTarget, speed, rotationSpeed, lengthBetweenNodee, brainTrnsfrm);
        } 
    }
}
