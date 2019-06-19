using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sensor> SENSORS;
    public static SensorManager I;
    public int MY_LAYER;
    
    void Awake()
    {
        MY_LAYER = LayerMask.NameToLayer("device");
        I = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
