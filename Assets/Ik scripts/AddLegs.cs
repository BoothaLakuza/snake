using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjcts : MonoBehaviour
{
    public Seg segScrpt;
    public List<GameObject> objctStore;
    public GameObject prefab;
    public int inner;
    [Range(0, 20)]
    public int countLeg;

    public bool can = false;
    GameObject newSegment;




    // Start is called before the first frame update
    void Start()
    {
        segScrpt = segScrpt.GetComponent<Seg>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (can)
        //{
        AddObjct();
        //}
    }

    void AddObjct()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

         

                //objctStore = GameObject.FindGameObjectsWithTag("leg");
                newSegment = (Instantiate(prefab, Vector2.zero, Quaternion.identity));
                objctStore.Add(newSegment);
            



            for (int i = 0; i < segScrpt.bodyParts.Count; i += 2)
            {




                newSegment.transform.SetParent(segScrpt.bodyParts[i]);
                for(int q = 0; q < objctStore.Count; q++)
                {
                  objctStore[q].transform.localPosition = Vector2.zero;

                }
                    
                        
                
                
                //foreach (Transform g in segScrpt.bodyParts[i].fin)
                //{
            }

        }



        //GameObject newSegment = (Instantiate(prefab, segScrpt.bodyParts[i].position, segScrpt.bodyParts[i].rotation));
        //objctStore.Add(newSegment);
        //newSegment.transform.SetParent(segScrpt.bodyParts[i]);




    }

}
