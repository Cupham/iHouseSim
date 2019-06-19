using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    public ITask CURRENT_TASK;
    public int id;
    public st_human ST_HUMAN;
    public HumanState MYSTATE = HumanState.SIT;
    int CURRENT_TASK_ID = 0;
    public NavMeshAgent AGENT;

    Vector3 destination_pos = Vector3.one*100000;
    public void Init(int id)
    {
        AGENT = GetComponent<NavMeshAgent>();
        this.id = id;
        ST_HUMAN = st_humanTable.getst_humanByID(id);
        GetComponent<HumanController>().enabled = false;

        MoveToTask(TaskManager.I.getTask(ST_HUMAN.task[0]));
        name = "human" + id;

        CameraFollow.I.MY_HUMAN = this.transform;
    }
    void Start()
    {

    }

    void Update()
    {
        switch(MYSTATE)
        {
            case HumanState.MOVE:
                if (Mathf.Sqrt((destination_pos.x - transform.position.x) * (destination_pos.x - transform.position.x)
                    + (destination_pos.z - transform.position.z) * (destination_pos.z - transform.position.z)) < 0.5f)
                    OnMoveTOTask();

            break;
        }
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
        Debug.Log("Try to do task: " + task.ST_TASK.Name + " on location: " + task.transform.position);
        CURRENT_TASK = task;
        //transform.DOMove(task.transform.position, 1).OnComplete(() =>
        //{
        //    OnMoveTOTask();
        //});
        MYSTATE = HumanState.MOVE;
        destination_pos = task.transform.position;
        AGENT.SetDestination(task.transform.position);
    }
    public void OnMoveTOTask()
    {
        Debug.Log("Moved to Task");
        DoTask();
    }
    public void DoTask()
    {
        MYSTATE = HumanState.SIT;
        StartCoroutine(TaskTimeOut(CURRENT_TASK.ST_TASK.time_out));
    }
    IEnumerator TaskTimeOut(float t)
    {
        while (t >= 0)
        {
            Debug.Log("task " + CURRENT_TASK.ST_TASK.Name + " count down: " + t);
            yield return new WaitForSeconds(1);
            t -= 1;
            
        }
        OnFinishTask();
    }
    public void OnFinishTask()
    {
        NextTask();
    }
    public void NextTask()
    {
        int task_id;
        do
        {
            task_id = Random.Range(0, st_taskTable.I.VALUE.Count);
        }
        while (task_id == CURRENT_TASK.ID);
        ITask task = TaskManager.I.getTask(task_id);
        if (task == null) Debug.Log("ERROR: TASK id " + task_id + " is not exist!");
        else MoveToTask(task);

    }

}
public enum HumanState 
{
    MOVE,
    SIT,
}
