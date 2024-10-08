using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomIkHandler : MonoBehaviour
{
    [Header("Joints")]
    public Transform joint0;
    public Transform joint1;
    public Transform controllerJoint;

    [Header("Targets")]
    public Transform target;


    private float length0, length1;

    // Start is called before the first frame update
    void Start()
    {
        length0 = Vector2.Distance(joint0.position, joint1.position);
        length1 = Vector2.Distance(joint1.position, controllerJoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        float jointAngle0;
        float jointAngle1;
        float length2 = Vector2.Distance(joint0.position, target.position);
        // Angle from Joint0 and Target
        Vector2 diff = target.position - joint0.position;
        float atan = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        // Is the target reachable?
        // If not, we stretch as far as possible
        if (length0 + length1 < length2)
        {
            jointAngle0 = atan;
            jointAngle1 = 0f;
        }
        else
        {
            float cosAngle0 = ((length2 * length2) + (length0 * length0) - (length1 * length1)) / (2 * length2 * length0);
            float angle0 = Mathf.Acos(cosAngle0) * Mathf.Rad2Deg;
            float cosAngle1 = ((length1 * length1) + (length0 * length0) - (length2 * length2)) / (2 * length1 * length0);
            float angle1 = Mathf.Acos(cosAngle1) * Mathf.Rad2Deg;
            // So they work in Unity reference frame
            jointAngle0 = atan - angle0;
            jointAngle1 = 180f - angle1;
        }

        Vector3 Euler0 = joint0.transform.localEulerAngles;
        Euler0.z = jointAngle0;
        joint0.transform.localEulerAngles = Euler0;
        Vector3 Euler1 = joint1.transform.localEulerAngles;
        Euler1.z = jointAngle1;
        joint1.transform.localEulerAngles = Euler1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(joint0.position, 0.1f);
        Gizmos.DrawWireSphere(joint1.position, 0.1f);
    }
}
