using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    //public int ID;
    public Transform humanPos;
    public st_sensor ST_SENSOR;
    public string ID;
    public GameObject LIGHT_GO;
    void Start()
    {
        ID = name;
        ST_SENSOR = st_sensorTable.getst_sensorByID(ID);
        if(ST_SENSOR==null)
        {
            Debug.Log("ERROR: CAN NOT FIND " + ID + " in st_sensor");
            if(gameObject.layer != SensorManager.I.MY_LAYER)
                Debug.Log("ERROR: " + name + " layer not set" );
        }

        Collider c = GetComponent<Collider>();
        if(c.isTrigger != true)
            c.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == HumanManager.I.MY_LAYER)
        {
           // Debug.Log("Triigered");
            if (ST_SENSOR.Type == "LIGHT")
            {
                //if (LIGHT_GO == null) LIGHT_GO = GetComponentInChildren<Light>();
                if (LIGHT_GO != null) LIGHT_GO.active = !LIGHT_GO.active;
            }
            //else if (ST_SENSOR.Type == "AIRCONDITIONER")
            //{
            //    //if (LIGHT_GO == null) LIGHT_GO = GetComponentInChildren<Light>();
            //    if (LIGHT_GO != null) LIGHT_GO.active = !LIGHT_GO.active;
            //}
            else Debug.Log("Trigger " + ST_SENSOR.Type);
        }
    }
    public void OnTriggerExit(Collider c )
    {
        if (c.gameObject.layer == HumanManager.I.MY_LAYER)
        {
//Debug.Log("exit");
        }
    }
    

    public void Turn(SensorState desire)
    {
        if (ST_SENSOR.Type == "AIRCONDITIONER")
        {

        }
        else Debug.Log("NOT SUPPORT YET : type = " + ST_SENSOR.Type); 
    }
    public SensorState MYSTATE;
}
public enum SensorState
{
    ON,
    OFF,
    OPEN,
    CLOSED,

}
