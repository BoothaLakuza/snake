using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrainControll : MonoBehaviour
{
    public float speed =2f;
    public float rotationSpeed = 256f; 
    Vector3 currentVel;
    public Transform rotator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             if (Input.GetKey(KeyCode.W))
        {
            //curspeed *= 2;
            transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        }
        else if(Input.GetKey(KeyCode.S)){
             transform.Translate(-transform.right * speed * Time.deltaTime, Space.World);
        }

      if (Input.GetAxis("Horizontal") != 0)
      {

            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
      }
     
          

    }
}
