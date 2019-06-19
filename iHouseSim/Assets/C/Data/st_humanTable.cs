using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_humanTable  
{
private static st_humanTable _instance;
public Dictionary<int, st_human> VALUE;
public st_humanTable()
{
	VALUE = new Dictionary<int, st_human>();
}
public static st_humanTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_humanTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_human Get(int id)
{
return VALUE[id];
}
public void load()
{
st_human t;
t = new st_human();
t.id=0;
t.name="nguoi0";
t.task= new int[3];
t.task[0]=0;
t.task[1]=1;
t.task[2]=0;
VALUE.Add(0, t);

t = new st_human();
t.id=1;
t.name="nguoi1";
t.task= new int[3];
t.task[0]=1;
t.task[1]=0;
t.task[2]=1;
VALUE.Add(1, t);

t = new st_human();
t.id=2;
t.name="nguoi2";
t.task= new int[3];
t.task[0]=0;
t.task[1]=1;
t.task[2]=1;
VALUE.Add(2, t);
}
public static st_human getst_humanByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
