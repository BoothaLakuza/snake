using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatmous : MonoBehaviour
{
    public Rigidbody2D rb;
    public float strength = 100;
    public float rotX;
    public float rotY;

    Vector2 rotV;
    float angle;
    public float prob, rotationAngle = 0f;
    public bool isRight = true, iCan = false;

    public Transform target;

    public float speed; 
    float angle1; 

    private void Awake()
    {
       
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

    }

    void FixedUpdate()
    {
        rotationAngle = (rotationAngle < 0f) ? rotationAngle + 180f : (rotationAngle > 180f ? rotationAngle - 180f : rotationAngle);
        faceMouse();
    }

    void faceMouse()
    {
        if (Input.GetMouseButton(0)) 
        { 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LookAtTarger(mousePosition);
        }
        if (iCan)
        {
            Debug.Log(rotV);
            LookAtTarger(target.position);
        }

        }
    void LookAtTarger(Vector2 target)
    {
        angle = Mathf.Atan2(target.x - transform.localPosition.x, target.y - transform.localPosition.y) * Mathf.Rad2Deg; //Get mouse angle
        //rb.rotation %= 360; // dont remember why i did this but better dont remove it
        angle = (angle + rb.rotation); // Sum up rigidbody and mouse angle
        if (angle < 0)
        {
            angle1 = 360.0f + angle;
        }
        else
        {
            angle1 = 360.0f - angle; // calculates negative angle
        }
        if (Mathf.Abs(angle) > Mathf.Abs(angle1) && angle < 0)
        {
            angle = angle1;
        }
        if (Mathf.Abs(angle) > Mathf.Abs(angle1) && angle > 0)
        {
            angle = angle1 * -1; // from my testing i found out that by writing these ifs rigid body stops doing awkward 360 turnadounds and spins trough closest path to mouse
        }
        rb.AddTorque(-angle + 90);
    }

    }






