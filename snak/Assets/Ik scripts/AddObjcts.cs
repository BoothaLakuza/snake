using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLegs : MonoBehaviour
{

    public int currentSegment = 0;

    public Seg segScrpt;
    public List<GameObject> objctStore;
    public GameObject prefab;
    public int inner;
    [Range(0, 20)]
    public int countLeg;

    public bool can = false;
    GameObject newSegment;

    void Start()
    {
        segScrpt = segScrpt.GetComponent<Seg>();
    }

    void Update()
    {
        AddObjct();
            Debug.Log(currentSegment);
    }

    void AddObjct()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currentSegment == -1)
                return;

            newSegment = (Instantiate(prefab, Vector2.zero, Quaternion.identity));
            objctStore.Add(newSegment);

            //for (int i = 0; i < segScrpt.bodyParts.Count; i += 2)
            //{
            newSegment.transform.SetParent(segScrpt.bodyParts[currentSegment]);
            for (int q = 0; q < objctStore.Count; q++)
            {
                objctStore[q].transform.localPosition = Vector2.zero;

            }
            //}
            currentSegment += 2;

            if (currentSegment > segScrpt.bodyParts.Count)
                currentSegment = -1;
        }
    }
}
