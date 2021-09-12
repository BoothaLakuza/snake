using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJoint : MonoBehaviour
{
    public Transform ConnectedRigidbody;
    public bool DetermineDistanceOnStart = true;
    public float Distance;
    public float Spring = 0.1f;
    public float Damper = 5f;

    protected Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (DetermineDistanceOnStart && ConnectedRigidbody != null)
            Distance = Vector3.Distance(rb2d.position, ConnectedRigidbody.position);
    }

    void FixedUpdate()
    {

        var connection = rb2d.position - (Vector2)ConnectedRigidbody.position;
        var distanceDiscrepancy = Distance - connection.magnitude;

        rb2d.position += distanceDiscrepancy * connection.normalized;

        var velocityTarget = connection + (rb2d.velocity + Physics2D.gravity * Spring);
        var projectOnConnection = Vector3.Project(velocityTarget, connection);
        rb2d.velocity = (velocityTarget - (Vector2)projectOnConnection) / (1 + Damper * Time.fixedDeltaTime);


    }
}
