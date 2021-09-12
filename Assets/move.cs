using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 14f, jForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector2 h = new Vector2(hor, 0f);
        Vector2 v = new Vector2(0f, ver);
        Vector2 dirT = Camera.main.WorldToScreenPoint(Input.mousePosition);
            Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(rb.position);
        Vector2 direction = dir / dir.magnitude;
        //Debug.Log(direction);
        // Debug.Log(dirT);

        if (hor != 0)
        {
            rb.AddForce(h * force, ForceMode2D.Force);
        }
        if (ver > 0)
        {
            rb.AddForce(direction * force, ForceMode2D.Force);
        }
        else if (ver < 0)
        {
            rb.AddForce(-direction * force, ForceMode2D.Force);
        }

        if (Input.GetMouseButton(0) && Input.GetKeyDown(KeyCode.Space))
        {
            //Vector2 dir = Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position;
            //dir.Normalize();
            //Debug.Log(dir);
            rb.AddForce(direction * jForce, ForceMode2D.Impulse);

        }
        //Debug.Log(rb.velocity);

        /// rotationAngle = (rotationAngle < 0f) ? rotationAngle + 360f : (rotationAngle > 360f ? rotationAngle - 360f : rotationAngle);
    }
}
