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
    public DevicesScheduleofHuman DEVVICE_SHEDULE_OF_HUMAN;

    Vector3 destination_pos = Vector3.one*100000;
    DailyTasks MY_DAILY_TASK;

    public void Init(int id)
    {
        

        AGENT = GetComponent<NavMeshAgent>();
        this.id = id;
        ST_HUMAN = st_humanTable.getst_humanByID(id);
        MY_DAILY_TASK = new DailyTasks(ST_HUMAN.Monday);
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
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("F1: " + DEVVICE_SHEDULE_OF_HUMAN.ToString());
        }
#endif

        switch(MYSTATE)
        {
            case HumanState.MOVE:
                Debug.DrawLine(transform.position, destination_pos, Color.green);
                if (Mathf.Sqrt((destination_pos.x - transform.position.x) * (destination_pos.x - transform.position.x)
                    + (destination_pos.z - transform.position.z) * (destination_pos.z - transform.position.z)) < 0.5f)
                    OnMoveTOTask();
                count++; 
                if(count >= 30) 
                {
                    count = 0;
                    if(Vector3.Distance(last_pos,transform.position) < 0.1f) 
                    {
                        Debug.LogWarning("ERROR: CAN NOT REACH TASK " + EXPECTED_TASK.ST_SCHEDULE.TaskName + " ON FLOOR: " + EXPECTED_TASK.ST_SCHEDULE.Floor +  "; FORCE MOVE: " + destination_pos);
                        AGENT.Stop();
                        transform.position = destination_pos;
                        DoTask(EXPECTED_TASK);
                    }
                    last_pos = transform.position;
                }
                break;
            case HumanState.MOVE_TO_SENSOR:
                Debug.DrawLine(transform.position, destination_pos, Color.blue);
                if (Mathf.Sqrt((destination_pos.x - transform.position.x) * (destination_pos.x - transform.position.x)
                    + (destination_pos.z - transform.position.z) * (destination_pos.z - transform.position.z)) < 0.5f)
                    OnMoveToSensor();
                count++;
                if (count >= 30)
                {
                    count = 0;
                    if (Vector3.Distance(last_pos, transform.position) < 0.1f)
                    {
                        //Debug.Log(MYSTATE + " <" + DEVVICE_SHEDULE_OF_HUMAN + "> " + name  );
                        if (DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor() == null) Debug.LogWarning("ERROR: DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor() == null");
                        Debug.LogWarning("ERROR: CAN NOT REACH SENSOR " + DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor().name + " ; FORCE MOVE: " + destination_pos);
                        AGENT.Stop();
                        transform.position = destination_pos;
                        OnMoveToSensor();
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
    public void MoveToSensor(Sensor s)
    {
        Debug.Log("Trying to set sensor: " + s.name + " state to " + DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor_EXpectedvalue()
);

        MYSTATE = HumanState.MOVE_TO_SENSOR;
        if (s.ST_SENSOR.Floor != CURRENT_TASK.ST_SCHEDULE.Floor) Debug.LogWarning("ERROR: wrong floor sensor: " + s.name + " schedule:" + CURRENT_TASK.ST_SCHEDULE.TaskName);
        if (s.LIGHT_GO != null)
        {
            destination_pos = s.LIGHT_GO.transform.position;
        }
        else
        {
            Debug.LogWarning("ERROR: LIGHT_GO of " + s.name + " was not set, Move to sensor instead");
            destination_pos = s.transform.position;
        }

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
            Teleport(task.transform.position);
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
    public void OnMoveToSensor()
    {
        Sensor s = DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor();
        s.Turn(DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor_EXpectedvalue());
        s.MYSTATE = DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor_EXpectedvalue();
        Debug.Log("Just set sensor " + s.name + "  state to " + DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor_EXpectedvalue());

        DEVVICE_SHEDULE_OF_HUMAN.OnFinishSensorTask();
        TryToDoDeviceShedule();
    }
    public void DoTask(ITask task)
    {
        CURRENT_TASK = task;
        DEVVICE_SHEDULE_OF_HUMAN = new DevicesScheduleofHuman(task.ST_SCHEDULE);
        if (DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor() != null)
        {
            TryToDoDeviceShedule();
        }
        else DoTaskReal(CURRENT_TASK);
    }
    public void DoTaskReal(ITask task)
    {
        Debug.Log("Begin DO Task " + task.ST_SCHEDULE.TaskName);
        //CURRENT_TASK = task;
        MYSTATE = HumanState.SIT;
        StartCoroutine(TaskTimeOut(2));
    }
    public void TryToDoDeviceShedule()
    {
        Sensor s = DEVVICE_SHEDULE_OF_HUMAN.GetCurrentSensor();
        if (s == null)
        {
            MoveToTask(CURRENT_TASK);
        }
        else
        {
            MoveToSensor(s);
        }
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
        Debug.Log("OnFinishTask(): " + CURRENT_TASK.name);
        NextTask();
    }
    public void NextTask()
    {
        ITask task = MY_DAILY_TASK.GetNextSchedule();
        if(task!=null)
            MoveToTask(task);
        else
        {
            Debug.Log("NEW DAY!!!");
            MY_DAILY_TASK = new DailyTasks(ST_HUMAN.Monday);
            MoveToTask(task);
        }
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
    MOVE_TO_SENSOR,
    SIT,
}

public class DevicesScheduleofHuman
{
    public int ID_CURRENT_ID;
    public List<Sensor> SENSORS = new List<Sensor>();
    public List<SensorState> SENSORS_EXPECTED_VALUE = new List<SensorState>();
    public DevicesScheduleofHuman(st_schedule ST_SCHEDLE)
    {
        SENSORS = new List<Sensor>();
        SENSORS_EXPECTED_VALUE = new List<SensorState>();
        string devices_s = ST_SCHEDLE.Device;
        string[] devices_s_array = devices_s.Split('|');
        foreach (string devices_string in devices_s_array)
        {
            if (devices_string.Length == 0) continue;
            string[] parse = devices_string.Split(':');
            if (parse.Length != 2) Debug.LogWarning("ERROR: CAN NOT PARSE " + devices_string + " on ST_SCHEDULE id = " + ST_SCHEDLE.id);
            SensorState state_designed = (SensorState)int.Parse(parse[1]);
            Sensor sensor = SensorManager.I.GetSensor(parse[0]);
            if (sensor == null) Debug.LogWarning("ERROR: CAN NOT FOUND SENSOR WITH ID= " + parse[0]);
            SENSORS.Add(sensor);
            SENSORS_EXPECTED_VALUE.Add(state_designed);
        }
    }
    public int OnFinishSensorTask()
    {
        ID_CURRENT_ID++;
        if (ID_CURRENT_ID >= SENSORS.Count) return -1;
        return ID_CURRENT_ID;
    }
    public Sensor GetCurrentSensor()
    {
        if (ID_CURRENT_ID >= SENSORS.Count) return null;
        if(SENSORS[ID_CURRENT_ID].MYSTATE == SENSORS_EXPECTED_VALUE[ID_CURRENT_ID])
        {
            OnFinishSensorTask();
            return GetCurrentSensor();
        }
        return SENSORS[ID_CURRENT_ID];
    }
    public SensorState GetCurrentSensor_EXpectedvalue()
    {
        if (ID_CURRENT_ID >= SENSORS.Count) return SensorState.OFF;
        return SENSORS_EXPECTED_VALUE[ID_CURRENT_ID];
    }

    public string ToString()
    {
        string s = "";
        //foreach(Sensor se in SENSORS)
        for (int i = 0; i < SENSORS.Count; i++)
        {
            s += "(" + SENSORS[i].name + ":" + SENSORS[i].MYSTATE + "->" + SENSORS_EXPECTED_VALUE[i] + ") ";
            if (i == ID_CURRENT_ID) s += "HUMAN";
        }
        return s;
    }
}

