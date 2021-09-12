using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.IK;

public class AD : MonoBehaviour
{
    private int currentSegment = 0;

    public Seg segScrpt;
    public GameObject prefab, ikPrefab;
  
    GameObject newSegment, childGO;

    public Transform legR, legL;

    public List<GameObject> objctStore;
    public List<Transform> target1;
    public List<Transform> target2;
    public List<Transform> leg;
    public List<Transform> legl;

    void Start()
    {
        segScrpt = segScrpt.GetComponent<Seg>();
    }

    void Update()
    {
        AddObjct();
    }

    void AddObjct()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentSegment == -1)
                return;

            newSegment = (Instantiate(prefab, Vector2.zero, Quaternion.identity));
            objctStore.Add(newSegment);


            newSegment.transform.SetParent(segScrpt.bodyParts[currentSegment]);
            for (int q = 0; q < objctStore.Count; q++)
            {
                objctStore[q].transform.localPosition = Vector2.zero;


            }

            currentSegment += 2;

            if (currentSegment > segScrpt.bodyParts.Count)
            {
                currentSegment = -1;
            }
            
            foreach (Transform g in segScrpt.bodyParts[currentSegment].GetComponentsInChildren<Transform>())
            {
                if (g.tag == "body")
                {
                    childGO = (Instantiate(ikPrefab, segScrpt.bodyParts[currentSegment].position, segScrpt.bodyParts[currentSegment].rotation));
                    childGO.transform.SetParent(g);

                    foreach(Transform x in childGO.GetComponentsInChildren<Transform>())
                    {
                        Transform one = x.Find("t1");
                        if (one != null)
                            target1.Add(one);

                        Transform two = x.Find("t2");
                        if (two != null)
                            target2.Add(two);
                    }
                }
            }

            foreach (Transform g in newSegment.GetComponentsInChildren<Transform>())
            {
              
                    legR = g.Find("legfootR");
                if(legR != null)
                leg.Add(legR);

                legL = g.Find("legfootL");
                if (legL != null)
                    legl.Add(legL);


            }
                     
            }
        
    }

}
