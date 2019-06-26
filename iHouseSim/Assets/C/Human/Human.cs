using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    public ITask CURRENT_TASK=null;
    public ITask EXPECTED_TASK = null;
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

        ITask itask = TaskManager.I.TASKS[1001];
        transform.position = itask.transform.position;
        Debug.Log("trying to set posion" + itask.transform.position);
        DoTask(itask); 
        name = "human" + id;
        CameraFollow.I.MY_HUMAN = this.transform;
    }
    void Start()
    {

    }
    Vector3 last_pos;
    int count=0;
    void Update()
    {
        switch(MYSTATE)
        {
            case HumanState.MOVE:
                    if (Mathf.Sqrt((destination_pos.x - transform.position.x) * (destination_pos.x - transform.position.x)
                        + (destination_pos.z - transform.position.z) * (destination_pos.z - transform.position.z)) < 0.5f)
                        OnMoveTOTask();
                count++; 
                if(count >= 30) 
                {
                    count = 0;
                    if(Vector3.Distance(last_pos,transform.position) < 0.1f) 
                    {
                        Debug.Log("ERROR: CAN NOT REACH TASK " + EXPECTED_TASK.ST_SCHEDULE.TaskName + " ON FLOOR: " + EXPECTED_TASK.ST_SCHEDULE.Floor +  "; FORCE MOVE: " + destination_pos);
                        //
                        AGENT.Stop();
                        transform.position = destination_pos;
                        //AGENT.Move(destination_pos);
                        DoTask(EXPECTED_TASK);
                        //OnMoveTOTask();
                    }
                    last_pos = transform.position;
                }
                

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


    //ITask CURRENT_STAIR =null;
    public void MoveToTask(ITask task)
    {
        EXPECTED_TASK = task;
        if (CURRENT_TASK != null && CURRENT_TASK.ST_SCHEDULE.Floor != EXPECTED_TASK.ST_SCHEDULE.Floor)
        {
            CURRENT_TASK = TaskManager.I.GetStair(CURRENT_TASK.ST_SCHEDULE.Floor);
            MoveToStair();
        }
        else
        {
            Debug.Log("Try to do task: " + task.ST_SCHEDULE.TaskName + " on location: " + task.transform.position);
            MYSTATE = HumanState.MOVE;
            destination_pos = task.transform.position;
            AGENT.SetDestination(task.transform.position);
            AGENT.Resume();
        }
    }
    public void MoveToStair()
    {
        
        Debug.Log("Try to move to stair");
        MYSTATE = HumanState.MOVE;
        CURRENT_TASK = TaskManager.I.GetStair(CURRENT_TASK.ST_SCHEDULE.Floor);
        destination_pos = CURRENT_TASK.transform.position;
        AGENT.SetDestination(destination_pos);
        AGENT.Resume();
    }
    public void OnMoveTOTask()
    {
        MYSTATE = HumanState.SIT;
        AGENT.isStopped = true;
        if (CURRENT_TASK && CURRENT_TASK.ST_SCHEDULE.stair==1 )
        {
            
            ITask  task = TaskManager.I.GetNextStair(CURRENT_TASK);
            //transform.position = task.transform.position; 
            Teleport(task.transform.position);
            //AGENT.Move(task.transform.position);
            Debug.Log(CURRENT_TASK.ST_SCHEDULE.TaskName);
            Debug.Log("Moved to stair: ->  " + task.transform.position);
            
            CURRENT_TASK = null;
            MoveToTask(EXPECTED_TASK); 
        }
        else
        {
            Debug.Log("Moved to Task");
            DoTask(EXPECTED_TASK);
        }
    }
    public void DoTask(ITask task)
    {
        Debug.Log("Begin DO Task " + task.ST_SCHEDULE.TaskName);
        CURRENT_TASK = task;
        MYSTATE = HumanState.SIT;
        StartCoroutine(TaskTimeOut(2));
    }
    IEnumerator TaskTimeOut(float t)
    {
        while (t >= 0)
        {
            Debug.Log("task " + CURRENT_TASK.ST_SCHEDULE.TaskName + " count down: " + t);
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
        int task_id = Random.Range(0, 10);
        ITask task=null;
        while(task== null || task.ST_SCHEDULE.stair != 0)
        {
            task_id = Random.Range(0, 10);
            task = TaskManager.I.getTask(task_id);
        }
        //if (task == null) Debug.Log("ERROR: TASK id " + task_id + " is not exist!");
        //else
        MoveToTask(task);

    }

    public void Teleport(Vector3 p)
    {
        AGENT.Stop(true);
        AGENT.updatePosition = false;
        AGENT.updateRotation = false;
        AGENT.enabled = false;
        transform.position = p;
        AGENT.enabled = true;
        AGENT.updatePosition = true;
        AGENT.updateRotation = true;
    }

}
public enum HumanState 
{
    MOVE,
    SIT,
}
