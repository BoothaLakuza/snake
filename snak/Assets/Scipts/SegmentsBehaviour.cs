using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsBehaviour : MonoBehaviour
{
     public List<Transform> bodyParts = new List<Transform>();
     public float factor,amplitude, speed;
    // Start is called before the first frame update
    void Start()
    {
         Vector2 pos = transform.position;
    

        // for (int j = 1; j < bodyParts.Count; j++)
        // {
        //     pos.x -= lengthBetweenNode;
        //     bodyParts[j].position = pos;
        // }
    }

    // Update is called once per frame
    void Update()
    {
         for (int i = 0; i < bodyParts.Count; i++)
        {
        Vector3 position = bodyParts[i].localPosition ;
        //position.y = Mathf.Sin(Time.time + i  *factor) * amplitude ;
        position.y = Mathf.PingPong(Time.time + i * factor, amplitude);
        bodyParts[i].localPosition = position;


         //var popa =  bodyParts[i].GetChild(i);
         //   Debug.Log(popa.name);
        }
    }
}
