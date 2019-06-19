using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform MY_HUMAN;
    public Vector3 OFFSET = new Vector3(0, 8, -5);
    public static CameraFollow I;
        void Awake()
    {
        I = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = MY_HUMAN.transform.position + OFFSET;
        transform.LookAt(MY_HUMAN);
    }
}
