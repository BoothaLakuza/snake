using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegDataHandler : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public Transform brainTrnsfrm;
    public float beginSize, speed, rotationSpeed, lengthBetweenNodee;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bodyParts.Count; i++)
        {
            Transform followTarget = i == 0 ? transform : bodyParts[i - 1];
            bodyParts[i].GetComponent<SegData>().EnterFollowLine(followTarget);
        }
    }
}
