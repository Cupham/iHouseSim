using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITask : MonoBehaviour
{
    public int ID;
    public st_schedule ST_SCHEDULE;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(string name)
    {
        ST_SCHEDULE = st_scheduleTable.getst_scheduleByID(ID);
        if (ST_SCHEDULE == null) Debug.Log("ERROR: TASK " + name + " NOT EXIST IN st_task table");
    }
}
