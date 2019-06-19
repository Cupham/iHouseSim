using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_houseTable  
{
private static st_houseTable _instance;
public Dictionary<string, st_house> VALUE;
public st_houseTable()
{
	VALUE = new Dictionary<string, st_house>();
}
public static st_houseTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_houseTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_house Get(string id)
{
return VALUE[id];
}
public void load()
{
st_house t;
t = new st_house();
t.id="Bedroom3";
t.Name="Sleep";
t.Activity="Sleep";
t.Start_time="0:00";
t.End_Time="7:29";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);

t = new st_house();
t.id="Toilet_2";
t.Name="Personal Care";
t.Activity="BrushTooth";
t.Start_time="7:29";
t.End_Time="7:32";
t.Location="Toilet_2";
VALUE.Add("Toilet_2", t);

t = new st_house();
t.id="Bedroom3";
t.Name="Personal Care";
t.Activity="Personal Care";
t.Start_time="7:32";
t.End_Time="7:37";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);

t = new st_house();
t.id="LivingRoom";
t.Name="Eat";
t.Activity="BreakFast";
t.Start_time="7:37";
t.End_Time="8:07";
t.Location="LivingRoom";
VALUE.Add("LivingRoom", t);

t = new st_house();
t.id="Entrance Hall";
t.Name="Going Out";
t.Activity="GotoSchool";
t.Start_time="8:07";
t.End_Time="8:30";
t.Location="Entrance Hall";
VALUE.Add("Entrance Hall", t);

t = new st_house();
t.id="School";
t.Name="Going Out";
t.Activity="SchoolWork";
t.Start_time="8:30";
t.End_Time="12:20";
t.Location="School";
VALUE.Add("School", t);

t = new st_house();
t.id="School";
t.Name="Going Out";
t.Activity="Lunch";
t.Start_time="12:20";
t.End_Time="12:50";
t.Location="School";
VALUE.Add("School", t);

t = new st_house();
t.id="School";
t.Name="Going Out";
t.Activity="SchoolWork";
t.Start_time="12:50";
t.End_Time="15:00";
t.Location="School";
VALUE.Add("School", t);

t = new st_house();
t.id="School";
t.Name="Going Out";
t.Activity="Moving";
t.Start_time="15:00";
t.End_Time="15:23";
t.Location="School";
VALUE.Add("School", t);

t = new st_house();
t.id="Entrance Hall";
t.Name="Going Out";
t.Activity="Study";
t.Start_time="15:23";
t.End_Time="16:49";
t.Location="Entrance Hall";
VALUE.Add("Entrance Hall", t);

t = new st_house();
t.id="Bedroom3";
t.Name="SchoolWork";
t.Activity="HomeWork";
t.Start_time="16:49";
t.End_Time="17:49";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);

t = new st_house();
t.id="Bedroom3";
t.Name="Rest";
t.Activity="Rest";
t.Start_time="17:49";
t.End_Time="18:53";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);

t = new st_house();
t.id="LivingRoom";
t.Name="Eat";
t.Activity="Dinner";
t.Start_time="18:53";
t.End_Time="19:29";
t.Location="LivingRoom";
VALUE.Add("LivingRoom", t);

t = new st_house();
t.id="Bedroom3";
t.Name="Rest";
t.Activity="Rest";
t.Start_time="19:29";
t.End_Time="20:22";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);

t = new st_house();
t.id="LivingRoom";
t.Name="TV";
t.Activity="TV";
t.Start_time="20:22";
t.End_Time="21:58";
t.Location="LivingRoom";
VALUE.Add("LivingRoom", t);

t = new st_house();
t.id="BathRoom";
t.Name="Personal Care";
t.Activity="Bath";
t.Start_time="21:58";
t.End_Time="22:28";
t.Location="BathRoom";
VALUE.Add("BathRoom", t);

t = new st_house();
t.id="Toilet_2";
t.Name="Personal Care";
t.Activity="BrushTooth";
t.Start_time="22:28";
t.End_Time="22:31";
t.Location="Toilet_2";
VALUE.Add("Toilet_2", t);

t = new st_house();
t.id="Bedroom3";
t.Name="Sleep";
t.Activity="Sleep";
t.Start_time="22:31";
t.End_Time="0:00";
t.Location="Bedroom3";
VALUE.Add("Bedroom3", t);
}
public static st_house getst_houseByID(string id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
