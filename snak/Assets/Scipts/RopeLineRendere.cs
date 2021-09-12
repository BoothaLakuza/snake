using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLineRendere : MonoBehaviour
{
    List<Transform> t = new List<Transform>();
    LineRenderer lR;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform target in transform.GetComponentInChildren<Transform>())
        {
            t.Add(target);
        }
        lR = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            var points = new Vector3[t.Count];
        for(int i = 0; i < t.Count; i++)
        {
            points[i] = t[i].position;
        }
        lR.positionCount = t.Count;
        lR.SetPositions(points);
    }
}
