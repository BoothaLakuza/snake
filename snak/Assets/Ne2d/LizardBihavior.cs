using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardBihavior : MonoBehaviour
{
       private LineRenderer lineRenderer;
    [SerializeField] Transform target;
    //public List<Transform> parts;
    public List<Transform> bodyParts;
    Vector2 mp;
    public int segmentLength;
    public float bodySegLen = 0.25f;
    public List<Vector3> positions;
    public bool canFollow;
    public float lineWidth = 0.1f;
    public float maxAngleTurn;
    CircleCollider2D cCol2D;
    // Start is called before the first frame update
    private void Awake() {

    }
    void Start()
    {
        
        //lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        Vector3 bodyStartPoint = bodyParts[0].transform.position;
        for (int i = 0; i < bodyParts.Count; i++)
        {
            
            positions.Add(bodyParts[i].position);
            bodyStartPoint.x -= bodySegLen;
            bodyParts[i].transform.position = bodyStartPoint;
        }


    }
    public Vector3 forceGravity;
    // Update is called once per frame
    void Update()
    {

        
  
           bodyParts[0].position = target.position;
        
            
         

            for (int i = 0; i < bodyParts.Count; i++) {

                Vector3 velocity = bodyParts[i].position - positions[i];
                positions[i] = bodyParts[i].position;
                bodyParts[i].position += velocity;
            bodyParts[i].position += forceGravity * Time.deltaTime;
            // positions[i] = bodyParts[i].position;
            bodyParts[i].position = positions[i];

            //   RopeSegment firstSegment = this.ropeSegments[i];
            //  Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            //firstSegment.posOld = firstSegment.posNow;
            //firstSegment.posNow += velocity;
           // firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            //this.ropeSegments[i] = firstSegment;


            //cCol2D = bodyParts[i].GetComponent<CircleCollider2D>();
            //Debug.Log(cCol2D.radius);
        }

            for (int i = 0; i < 50; i++)
            {
                ConfigConstrains();
            }
       // DrawRope();
    }



        void ConfigConstrains() {
            for (int i = 0; i < segmentLength - 1; i++) {
                float dist = (bodyParts[i].position - bodyParts[i + 1].position).magnitude;
                float difference = Mathf.Abs(dist - bodySegLen);
                Vector3 changeDir = Vector2.zero;
                float percentage = difference / bodySegLen / 2;
                float offset = dist * percentage;
                if (dist > bodySegLen)
                {
                    changeDir = (bodyParts[i].position - bodyParts[i + 1].position).normalized;
                } else if (dist < bodySegLen)
                {
                    changeDir = (bodyParts[i + 1].position - bodyParts[i].position).normalized;
                }

                Vector3 changeAmount = changeDir * difference;
                if (i != 0)
                {
                    bodyParts[i].position -= changeAmount * 0.5f;
                    positions[i] = bodyParts[i].position;
                    bodyParts[i + 1].position += changeAmount * 0.5f;
                    positions[i + 1] = bodyParts[i + 1].position;
                }
                else
                {
                    bodyParts[i + 1].position += changeAmount;
                    positions[i + 1] = bodyParts[i + 1].position;
                }
                //positions[i] -= offset;

                //float lerpProgress = dist / bodySegLen;
                //     for (int a = 1; a < bodyParts.Count; a++)
                // {
                //bodyParts[i].position = Vector3.Lerp(positions[i], positions[i - 1], lerpProgress);
                //}
            }



            //for (int i = 1; i < bodyParts.Count; i++)
            //{

            //    Vector3 dir = (bodyParts[i - 1].position - bodyParts[i + 1].position).normalized;
            //    // bodyParts[i].rotation = Quaternion.LookRotation(dir);
            //    Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * dir;
            //    bodyParts[i].rotation = Quaternion.LookRotation(bodyParts[i - 1].position - bodyParts[i].position);

            //}
        }
    // public float startW, endW;
    // public bool useCurve;
    //      void DrawRope()
    //     {
    //     //float lineWidth = this.lineWidth;
    //     //lineRenderer.startWidth = startW;

    //     //lineRenderer.endWidth = endW;
    //         //lineRenderer.startWidth = cCol2D.radius;
    //     float addkeys = 0f;
    //     startW = 0f;
    //                 AnimationCurve curve = new AnimationCurve();
    //     Vector3[] ropePositions = new Vector3[segmentLength];
    //         for (int i = 0; i < segmentLength; i++)
    //         {
                
    //             ropePositions[i] = bodyParts[i].position;
    //             //float dist = (ropePositions[i] - ropePositions[i + 1]).magnitude;
    //             //Debug.Log(dist);
    //             //lineRenderer.startWidth = startW;
                    
    //             if(i != 0){
    //                 addkeys += bodySegLen;
    //                startW = bodyParts[i].GetComponent<CircleCollider2D>().radius;
    //                // startW += addkeys;
    //                 curve.AddKey(addkeys, startW * 20);
    //             }

    //                 // if(i != 0){
    //                 //   //  curve.AddKey(, cCol2D.radius);
                    
    //                 // }

    //         }


        
    //     // if (useCurve)
    //     // {
    //     //     curve.AddKey(0.0f, 0.0f);
    //     //     curve.AddKey(1.0f, 1.0f);
    //     // }
    //     // else
    //     // {
    //     //     curve.AddKey(0.0f, 1.0f);
    //     //     curve.AddKey(1.0f, 1.0f);
    //     // }

    //         lineRenderer.widthCurve = curve;
    //          lineRenderer.widthMultiplier = lineWidth;


    //         lineRenderer.positionCount = ropePositions.Length;
    //         lineRenderer.SetPositions(ropePositions);
    //     }

    // public struct LineRedne
    // {
    //     public float linewidthFirst;
    //     public float linewidthSecond;

    //     public LineRedne(float width/*, float widthSecond*/)
    //     {
    //         linewidthFirst = width;
    //         linewidthSecond = width;
    //     }
    // }

//   [SerializeField] Transform target;
//     //public List<Transform> parts;
//     public List<Transform> bodyParts;
//  Vector2 mp;
//     public float segmentLength;
//     public float bodySegLen = 0.25f;
//     public List<Vector3> positions;
//     public bool canFollow;
//     public Camera cum;
//     // Start is called before the first frame update
//     private void Awake() {

//     }
//     void Start()
//     {    
//          Vector3 bodyStartPoint = bodyParts[0].transform.position;
//               for (int i = 0; i < bodyParts.Count; i++)
//         {
//             positions.Add(bodyParts[i].position);
//             bodyStartPoint.x -= bodySegLen;
//             bodyParts[i + 1].transform.position = bodyStartPoint;
//         }

        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         cum = Camera.main;
//         if(canFollow == true){

//         mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         target.position = mp;
//         }
//         else if(canFollow == false){
//             target.position = target.position;
//         }
//         bodyParts[0].position = target.position;

//         for(int i = 0; i < bodyParts.Count; i++){
//             Vector3 velocity = bodyParts[i].position - positions[i];
//             positions[i] = bodyParts[i].position;
//             bodyParts[i].position += velocity;
//         }

//         for (int i = 0; i < 50; i++)
//         {
//             ConfigConstrains();
//         }
//     }


//     private void FixedUpdate() {
        
//     }
//     void ConfigConstrains(){
//         for (int i = 0; i < segmentLength - 1; i++){
//              float dist = (bodyParts[i].position - bodyParts[i + 1].position).magnitude;
//              float difference = Mathf.Abs(dist - bodySegLen);
//              Vector3 changeDir = Vector2.zero;
//              float percentage = difference / bodySegLen / 2;
//              float offset = dist * percentage;
//             if (dist > bodySegLen)
//             {
//                 changeDir = (bodyParts[i].position -  bodyParts[i + 1].position).normalized;
//             } else if (dist < bodySegLen)
//             {
//                 changeDir = ( bodyParts[i + 1].position - bodyParts[i].position).normalized;
//             }

//             Vector3 changeAmount = changeDir * difference;
//             if (i != 0)
//             {
//                 bodyParts[i].position -= changeAmount * 0.5f;
//                 positions[i] = bodyParts[i].position;
//                 bodyParts[i + 1].position += changeAmount * 0.5f;
//                 positions[i + 1] = bodyParts[i + 1].position;
//             }
//             else
//             {
//                 bodyParts[i + 1].position += changeAmount;
//                 positions[i + 1] = bodyParts[i + 1].position;
//             }
//              //positions[i] -= offset;

//             //float lerpProgress = dist / bodySegLen;
//             //     for (int a = 1; a < bodyParts.Count; a++)
//             // {
//                 //bodyParts[i].position = Vector3.Lerp(positions[i], positions[i - 1], lerpProgress);
//             //}
//         }
//         for(int i = 1; i < bodyParts.Count; i++){
                
//                  Vector3 dir = (bodyParts[i - 1].position - bodyParts[i + 1].position).normalized;
//                 // bodyParts[i].rotation = Quaternion.LookRotation(dir);
//                 Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * dir;
//                 bodyParts[i].rotation = Quaternion.LookRotation(bodyParts[i - 1].position - bodyParts[i].position);
                
//         }
//     }
}