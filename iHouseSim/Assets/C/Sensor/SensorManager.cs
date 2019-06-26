using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string,Sensor> SENSORS = new Dictionary<string, Sensor>(); 
    public static SensorManager I;
    public int MY_LAYER;

    
    void Awake()
    {
        MY_LAYER = LayerMask.NameToLayer("device");
        I = this;
        //Transform[] G = GetComponentsInChildren<Transform>();
        Sensor[] G = FindObjectsOfType<Sensor>(); 
        foreach (Sensor ss in G)
        {
            if (SENSORS.ContainsKey(ss.name))
                Debug.Log("ERROR: duplicated key " + ss.name + " in Sensors");
            else
                SENSORS.Add(ss.name, ss);
        }
       
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Sensor GetSensor(string id)
    {
        return SENSORS[id];
    }
    
}
