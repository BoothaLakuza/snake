using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float dist;
    public LayerMask mask;
    public float force;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, dist, mask ) ;
        float difDist = Vector2.Distance(transform.position, hit.point);
        if (difDist <= dist)
        {
            rb.AddForceAtPosition(Vector2.up * force, hit.point);
        }
    }
}
