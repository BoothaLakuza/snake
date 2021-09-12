using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopThrought : MonoBehaviour
{
    public Seg seg;
    public List<Transform> sas;
    // Start is called before the first frame update
    void Start()
    {
        sas = seg.GetComponent<Seg>().bodyParts;
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (var item in list.Skip(1))
        //{
        //    System.Diagnostics.Debug.WriteLine(item.ToString());
        //}
        ////If you want to skip any other element at index n, you could write this:

        for (int i = 0; i < sas.Count; i+=2)
        {
            Debug.Log(sas[i].name);
            //if (i % 2 == 0)
            //{
            //    Debug.Log(sas[i].name);
            //}
                

        }

    }
}
