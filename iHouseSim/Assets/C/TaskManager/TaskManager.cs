using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager I;
    public Dictionary<int,ITask> TASKS = new Dictionary<int, ITask>();
    public ITask STAIR1;
    public ITask STAIR2;
    void Awake()
    {
        I = this;
        Transform[] G = GetComponentsInChildren<Transform>();
        //Debug.Log(G.Length + "  aaaaaaaaaaaaaaaa"); 
        foreach (Transform g in G) 
        {
            if (g == transform) continue;
            ITask it = g.GetComponent<ITask>(); 
            if (it == null) Debug.LogWarning("ERROR: game object " + g.name + " was not assined any ITask class");
            else
            {
                it.Init(g.name);
                if(it.ST_SCHEDULE == null) Debug.Log(TASKS + " " + it.ST_SCHEDULE);
                if (!TASKS.ContainsKey(it.ST_SCHEDULE.id))
                {
                    TASKS.Add(it.ST_SCHEDULE.id, it);
                }
                else Debug.LogWarning("ERROR: task position duplicated : " + g.name + " id=" + it.ST_SCHEDULE.id );
            }
            
           
        }

        STAIR1 = getTask(999);
        STAIR2 = getTask(1000);
        if (STAIR1 == null || STAIR2 == null) Debug.LogWarning("ERROR: STARIS ARE NULL");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ITask getTask(int s)
    {
        if (!TASKS.ContainsKey(s))
            Debug.LogWarning("ERROR: KEY NOT FOUND key: " + s + " in scene (schedule)");
        return TASKS[s];
    }
    public ITask getRandomTask()
    {
        return TASKS[1];
    }
    void HardSet()
    {

    }
    public ITask GetNextStair(ITask current)
    {
        if (current == STAIR1) return STAIR2;
        if (current == STAIR2) return STAIR1;
        return null;
    }
    public ITask GetStair(int level)
    {
        if (level == 1) return STAIR1;
        if (level == 2) return STAIR2;
        return null;
    }
}
