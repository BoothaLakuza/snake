using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D.IK;

public class ikAdder : MonoBehaviour
{

    IKManager2D managerIk;
  
    public GameObject gObj;

    public AD adleg;
 
    void Start()
    {           
        managerIk = GetComponent<IKManager2D>();       
    }

    void Update()
    {
        
      
        if (Input.GetKeyDown(KeyCode.C))
        {
            InstIkSolver();
        }
    }

    void InstIkSolver()
    {

        GameObject newClone = Instantiate(gObj, Vector2.zero, Quaternion.identity);
        GameObject newCloneL = Instantiate(gObj, Vector2.zero, Quaternion.identity);
        newClone.name = "New LimbSolver2D";
        newCloneL.name = "New LimbSolver2DL";
        newClone.transform.SetParent(transform);
        newCloneL.transform.SetParent(transform);

        var solver = newClone.GetComponent<DK>();
        var solverL = newCloneL.GetComponent<DK>();
        managerIk.AddSolver(solver);
        managerIk.AddSolver(solverL);



        for(int i = 0; i < adleg.leg.Count; i++)
        {
            
            solver.m_Chain.effector = adleg.leg[i];
            solverL.m_Chain.effector = adleg.legl[i];
            solver.m_Chain.target = adleg.target1[i];
            solverL.m_Chain.target = adleg.target2[i];
        } 
        
    }

}
