using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyTasks 
{
   public List<int> TASK_IDs;
    public int TASK_INDEX;
   public DailyTasks(string s)
    {
        TASK_INDEX = -1;
        TASK_IDs = new List<int>();
        string[] S = s.Split('|');
        foreach(string ss in S)
        {
            TASK_IDs.Add(int.Parse(ss));
        }
    }
    public ITask GetNextSchedule()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + TASK_INDEX);
        TASK_INDEX++;
        if (TASK_INDEX >= TASK_IDs.Count) return null;
        return TaskManager.I.getTask(TASK_IDs[TASK_INDEX]);

    }
}
