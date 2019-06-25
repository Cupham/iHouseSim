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
t.Name="Child_1";
t.Monday="1|2|3|4|5|6|7|8|9|10|11|12";
t.Tuesday="1|2|3|4|5|6|7|8|9|10|11|12";
t.Wednesday="1|2|3|4|5|6|7|8|9|10|11|12";
t.Thursday="1|2|3|4|5|6|7|8|9|10|11|12";
t.Friday="1|2|3|4|5|6|7|8|9|10|11|12";
VALUE.Add(0, t);

t = new st_human();
t.id=1;
t.Name="Child_2";
t.Monday="";
t.Tuesday="";
t.Wednesday="";
t.Thursday="";
t.Friday="";
VALUE.Add(1, t);

t = new st_human();
t.id=2;
t.Name="Father";
t.Monday="";
t.Tuesday="";
t.Wednesday="";
t.Thursday="";
t.Friday="";
VALUE.Add(2, t);

t = new st_human();
t.id=3;
t.Name="Mother";
t.Monday="";
t.Tuesday="";
t.Wednesday="";
t.Thursday="";
t.Friday="";
VALUE.Add(3, t);
}
public static st_human getst_humanByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
