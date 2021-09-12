using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotation : MonoBehaviour
{
    SegmentsBehaviour sgB;
    public Animator[] anim;
    // Start is called before the first frame update
    void Start()
    {
        sgB = this.GetComponent<SegmentsBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < sgB.bodyParts.Count - 1; i++)
        {
            Transform firstSeg = sgB.bodyParts[i];
            Transform secondSeg = sgB.bodyParts[i + 1];
            var velocity = (firstSeg.position - secondSeg.position) / Time.deltaTime;
            velocity.Normalize();
            Debug.Log(velocity);
            anim[i].SetFloat("PosX", velocity.x);
            anim[i].SetFloat("PosY", velocity.y);
            anim[i].SetFloat("Magnitude", velocity.magnitude);
        }

    }
}
