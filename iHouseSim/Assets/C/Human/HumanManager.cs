using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public static HumanManager I;
    public int MY_LAYER;
    public Human humanDemo;
    List<Human> HUMANS = new List<Human>();
    void Awake()
    {
        MY_LAYER = LayerMask.NameToLayer("human");
        I = this;
    }
    void Start()
    {
        AddHuman(0);
    }
    void Update()
    {
        
    }
    public void AddHuman(int id)
    {
        GameObject g = Instantiate(humanDemo.gameObject) as GameObject;
        g.GetComponent<Human>().Init(id);
        g.transform.SetParent(transform);
    }
}
