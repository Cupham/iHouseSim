using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Human : MonoBehaviour
{
    
    // Start is called before the first frame update
    public HumanState MYSTATE = HumanState.SIT;
    void Start()
    {
        //MoveToCHeckPoint(checkPointManager.I.KITCHEN);
        //StartCoroutine(Task());
    }

    // Update is called once per frame
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
    IEnumerator Task()
    {
        yield return new WaitForSeconds(1);
        //while(true)
        {
            yield return new WaitForSeconds(3);
            MoveToCHeckPoint(checkPointManager.I.TV);
        }
    }
}
public enum HumanState 
{
    MOVE,
    SIT,
}
