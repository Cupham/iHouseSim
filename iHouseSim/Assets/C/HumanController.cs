using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    Rigidbody RIG;
    void Start()
    {
        RIG = GetComponent<Rigidbody>();
    }

    float f = 10;
    float max_speed = 6;  
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            RIG.AddForce(Vector3.forward*f, ForceMode.Acceleration); 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RIG.AddForce(Vector3.back * f, ForceMode.Acceleration);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            RIG.AddForce(Vector3.left * f, ForceMode.Acceleration);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RIG.AddForce(Vector3.right * f, ForceMode.Acceleration);
        }
        if (RIG.velocity.magnitude > max_speed)
        {
            RIG.velocity = RIG.velocity.normalized * max_speed;
        }
    }
}
