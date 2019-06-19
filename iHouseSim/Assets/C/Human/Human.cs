using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Human : MonoBehaviour
{
    public ITask CURRENT_TASK;
    public int id;
    public st_human ST_HUMAN;
    public HumanState MYSTATE = HumanState.SIT;
    int CURRENT_TASK_ID = 0;
    public void Init(int id)
    {
        this.id = id;
        ST_HUMAN = st_humanTable.getst_humanByID(id);
        GetComponent<HumanController>().enabled = false;

        MoveToTask(TaskManager.I.getTask(ST_HUMAN.task[0]));
    }
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void TurnOn(IDevice a)
    {
        a.TurnOnMe();
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDevice>()!=null)
        {
            TurnOn(other.GetComponent<IDevice>());
        }
    }
    public void MoveToCHeckPoint(Checkpoint a)
    {
        transform.DOMove(a.transform.position, 1);
    }
 
    public void MoveToTask(ITask task)
    {
        CURRENT_TASK = task;
        transform.DOMove(task.transform.position, 1);
    }
    public void OnMoveTOTask()
    {

    }
    public void DoTask()
    {
        
    }

}
public enum HumanState 
{
    MOVE,
    SIT,
}
