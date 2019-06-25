using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_scheduleTable  
{
private static st_scheduleTable _instance;
public Dictionary<int, st_schedule> VALUE;
public st_scheduleTable()
{
	VALUE = new Dictionary<int, st_schedule>();
}
public static st_scheduleTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_scheduleTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_schedule Get(int id)
{
return VALUE[id];
}
public void load()
{
st_schedule t;
t = new st_schedule();
t.id=1;
t.TaskName="Sleep_1";
t.Start_Time="00:00";
t.End_Time="07:18";
t.Floor=2;
t.Device="W_24:C|CL_24:C|D_24:C|BP_24:ON|L_24:OFF|A_24:ON";
VALUE.Add(1, t);

t = new st_schedule();
t.id=2;
t.TaskName="Personal_Care_1";
t.Start_Time="07:18";
t.End_Time="07:28";
t.Floor=2;
t.Device="BP_24:OFF|A_24:OFF|W_24:O|CL_24:O|CL_24:C|BP_24:ON|L_24:OFF|A_24:ON";
VALUE.Add(2, t);

t = new st_schedule();
t.id=3;
t.TaskName="Brush_Tooth_1";
t.Start_Time="07:28";
t.End_Time="07:33";
t.Floor=1;
t.Device="A_24:OFF|L_24:OFF|L_15:ON|WS_15:ON";
VALUE.Add(3, t);

t = new st_schedule();
t.id=4;
t.TaskName="BreakFast";
t.Start_Time="07:33";
t.End_Time="08:03";
t.Floor=1;
t.Device="A_13:OFF|L_15:OFF|L_132:ON|L_131:ON|C_132:O|C_131:O|W_132:O|W_131:O";
VALUE.Add(4, t);

t = new st_schedule();
t.id=5;
t.TaskName="GoToSchool_1";
t.Start_Time="08:03";
t.End_Time="18:34";
t.Floor=1;
t.Device="";
VALUE.Add(5, t);

t = new st_schedule();
t.id=6;
t.TaskName="Bath_1";
t.Start_Time="18:34";
t.End_Time="19:14";
t.Floor=1;
t.Device="L_24:ON|CL_24:O|L_16:ON|WS_16:ON";
VALUE.Add(6, t);

t = new st_schedule();
t.id=7;
t.TaskName="Rest_1";
t.Start_Time="19:14";
t.End_Time="19:38";
t.Floor=2;
t.Device="L_16:OFF|W_24:O|BP_24:ON";
VALUE.Add(7, t);

t = new st_schedule();
t.id=8;
t.TaskName="Dinner_1";
t.Start_Time="19:38";
t.End_Time="20:03";
t.Floor=1;
t.Device="BP_24:OFF|L_132:ON|L_131:ON|C_132:O|C_131:O|W_132:O|W_131:O";
VALUE.Add(8, t);

t = new st_schedule();
t.id=9;
t.TaskName="Brush_Tooth_12";
t.Start_Time="20:03";
t.End_Time="20:08";
t.Floor=1;
t.Device="L_15:ON|WS_15:ON";
VALUE.Add(9, t);

t = new st_schedule();
t.id=10;
t.TaskName="homework_1";
t.Start_Time="20:08";
t.End_Time="22:08";
t.Floor=2;
t.Device="W_24:C|A_24:ON";
VALUE.Add(10, t);

t = new st_schedule();
t.id=11;
t.TaskName="hobby1";
t.Start_Time="22:08";
t.End_Time="23:54";
t.Floor=2;
t.Device="BP_24:ON";
VALUE.Add(11, t);

t = new st_schedule();
t.id=12;
t.TaskName="Sleep_12";
t.Start_Time="23:54";
t.End_Time="00:00";
t.Floor=2;
t.Device="L_24:OFF";
VALUE.Add(12, t);

t = new st_schedule();
t.id=999;
t.TaskName="Stair_1";
t.Start_Time="";
t.End_Time="";
t.Floor=1;
t.Device="L_18:ON";
VALUE.Add(999, t);

t = new st_schedule();
t.id=1000;
t.TaskName="Stair_2";
t.Start_Time="";
t.End_Time="";
t.Floor=2;
t.Device="";
VALUE.Add(1000, t);
}
public static st_schedule getst_scheduleByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
