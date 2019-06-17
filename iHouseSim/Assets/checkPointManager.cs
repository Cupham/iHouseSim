using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Checkpoint KITCHEN;
    public Checkpoint TV;
     public static checkPointManager I;
     void Awake()
     {
         I = this;
     }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CheckPointV
{

}