using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager I;
    public Dictionary<int,ITask> TASKS = new Dictionary<int, ITask>();
    void Awake()
    {
        I = this;
        Transform[] G = GetComponentsInChildren<Transform>();
        //Debug.Log(G.Length + "  aaaaaaaaaaaaaaaa"); 
        foreach (Transform g in G) 
        {
            if (g == transform) continue;
            ITask it = g.GetComponent<ITask>(); 
            if (it == null) Debug.Log("ERROR: game object " + g.name + " was not assined any ITask class");
            else
            {
                it.Init(g.name);
                if(it.ST_SCHEDULE == null) Debug.Log(TASKS + " " + it.ST_SCHEDULE);
                if (!TASKS.ContainsKey(it.ST_SCHEDULE.id))
                {
                    TASKS.Add(it.ST_SCHEDULE.id, it);
                }
                else Debug.Log("ERROR: task position duplicated : " + g.name + " id=" + it.ST_SCHEDULE.id );
            }
            
           
        }
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
        return TASKS[s];
    }
    public ITask getRandomTask()
    {
        return TASKS[Random.Range(0, TASKS.Count)];
    }
    void HardSet()
    {

    }
}
