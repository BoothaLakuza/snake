using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    [Range(0, 1)]
    public float friction;

    protected Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = rb2d.velocity * (1 - friction);
        rb2d.angularVelocity = rb2d.angularVelocity * (1 - friction);
    }

}
