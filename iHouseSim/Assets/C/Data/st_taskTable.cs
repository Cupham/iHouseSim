using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_taskTable  
{
private static st_taskTable _instance;
public Dictionary<int, st_task> VALUE;
public st_taskTable()
{
	VALUE = new Dictionary<int, st_task>();
}
public static st_taskTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_taskTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_task Get(int id)
{
return VALUE[id];
}
public void load()
{
st_task t;
t = new st_task();
t.id=0;
t.Name="Sleep";
t.Activity="Sleep";
t.time_out=4;
t.asd=4;
t.Location="Bedroom2";
t.decice= new string[1];
t.decice[0]="";
t.device1="";
t.deve="";
VALUE.Add(0, t);

t = new st_task();
t.id=1;
t.Name="Personal Care";
t.Activity="BrushTooth";
t.time_out=4;
t.asd=4;
t.Location="Washroom";
t.decice= new string[1];
t.decice[0]="";
t.device1="";
t.deve="";
VALUE.Add(1, t);
}
public static st_task getst_taskByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
