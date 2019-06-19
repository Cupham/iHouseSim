using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITask : MonoBehaviour
{
    public int ID;
    public st_task ST_TASK;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(string name)
    {
        ST_TASK = st_taskTable.getst_taskByID(ID);
        if (ST_TASK == null) Debug.Log("ERROR: TASK " + name + " NOT EXIST IN st_task table");
    }
}
