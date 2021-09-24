using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComIntecratpr : MonoBehaviour
{
    public Seg seg;
    public Transform com;
    public float forc;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < seg.bodyParts.Count-1; i++)
        {
             rb = seg.bodyParts[i].GetComponent<Rigidbody2D>();
            //seg.bodyParts[i].position = Vector2.Lerp(seg.bodyParts[i].position, com.position,Time.deltaTime * forc);

            rb.MovePosition(Vector3.Lerp(seg.bodyParts[i].position, com.position,/* Time.fixedDeltaTime + i **/ forc));
        }
        //Vector3 CoM = Vector3.zero;
        //float c = 0f;

        //foreach (GameObject part in assembly)
        //{
        //    CoM += part.rigidbody.worldCenterOfMass * part.rigidbody.mass;
        //    c += part.rigidbody.mass;
        //}

        //CoM /= c;
    }
}
