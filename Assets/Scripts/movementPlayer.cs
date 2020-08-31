using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb.AddForce(new Vector3 (0,0,1) * speed);
        }

        if (Input.GetKey("down"))
        {
            rb.AddForce(new Vector3(0, 0, -1) * speed);
        }

        if (Input.GetKey("left"))
        {
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
        }

        if (Input.GetKey("right"))
        {
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        }
    }
}
