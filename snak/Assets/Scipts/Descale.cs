using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descale : MonoBehaviour
{
    //SegmentsBehaviour sgB;
    public Seg sgB;
    public float v, max, min;
    public List<Vector2>  scaleVectors;

    // Start is called before the first frame update

    void Start()
    {

        sgB = sgB.GetComponent<Seg>();

        for (int i = 0; i < sgB.bodyParts.Count; i++)
        {
            scaleVectors.Add(Vector2.zero);
        }

    }

    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            scaleVectors.Add(Vector2.zero);
        }


        scaleVectors[0] = new Vector2(max, max); // (v / 2f, v / 2f)
        for (int i = 1; i < scaleVectors.Count; i++)
        {
            scaleVectors[i] = new Vector2( max - i * v, max - i * v);
            if (scaleVectors[i].x < min)
            {
                scaleVectors[i] = new Vector2(min, min);
            }
        }

        for (int i = 0; i < sgB.bodyParts.Count; i++)
        {
            sgB.bodyParts[i].gameObject.transform.localScale = scaleVectors[i];
        }
    }
}
