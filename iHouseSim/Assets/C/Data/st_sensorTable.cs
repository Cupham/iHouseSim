using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_sensorTable  
{
private static st_sensorTable _instance;
public Dictionary<string, st_sensor> VALUE;
public st_sensorTable()
{
	VALUE = new Dictionary<string, st_sensor>();
}
public static st_sensorTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_sensorTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_sensor Get(string id)
{
return VALUE[id];
}
public void load()
{
st_sensor t;
t = new st_sensor();
t.id="D_11";
t.device="main_door11";
t.location="Outside";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.2.148";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_11", t);

t = new st_sensor();
t.id="HS_11";
t.device="HumiditySensor_11";
t.location="Entrance";
t.init_value="";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.100";
t.EOJ="001201";
t.EPC="";
t.Command="";
VALUE.Add("HS_11", t);

t = new st_sensor();
t.id="TS_11";
t.device="TemperatureSensor_11";
t.location="Entrance";
t.init_value="";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.100";
t.EOJ="001101";
t.EPC="";
t.Command="ssh echo 30 > 192.168.0.100/0xfffff/80";
VALUE.Add("TS_11", t);

t = new st_sensor();
t.id="MS_11";
t.device="PassageSensor_11";
t.location="Entrance Hall";
t.init_value="NO";
t.Type="MOTION_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("MS_11", t);

t = new st_sensor();
t.id="L_11";
t.device="Light_11";
t.location="Entrance Hall";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="YES";
t.IP="192.168.2.123";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_11", t);

t = new st_sensor();
t.id="L_12";
t.device="Light_12";
t.location="Kitchen";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.2.125";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_12", t);

t = new st_sensor();
t.id="D_12";
t.device="Door_12";
t.location="Kitchen";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.2.153";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_12", t);

t = new st_sensor();
t.id="F_12";
t.device="Fridge_12";
t.location="Kitchen";
t.init_value="ON";
t.Type="FRIDGE";
t.Active="";
t.IP="192.168.3.120";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("F_12", t);

t = new st_sensor();
t.id="HWP_12";
t.device="Hot water pot_12";
t.location="Kitchen";
t.init_value="ON";
t.Type="HOT_WATER_POT";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("HWP_12", t);

t = new st_sensor();
t.id="MO_12";
t.device="Micro Oven_12";
t.location="Kitchen";
t.init_value="OFF";
t.Type="OVEN";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("MO_12", t);

t = new st_sensor();
t.id="CH_12";
t.device="Cooking Heater_12";
t.location="Kitchen";
t.init_value="OFF";
t.Type="STOVE";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("CH_12", t);

t = new st_sensor();
t.id="RC_12";
t.device="Rice Cooker_12";
t.location="Kitchen";
t.init_value="OFF";
t.Type="COOKER";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("RC_12", t);

t = new st_sensor();
t.id="WS_12";
t.device="WaterFlowSensor12";
t.location="Kitchen";
t.init_value="OFF";
t.Type="WATER_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("WS_12", t);

t = new st_sensor();
t.id="GS_12";
t.device="GasLeakedSensor12";
t.location="Kitchen";
t.init_value="ON";
t.Type="GAS_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("GS_12", t);

t = new st_sensor();
t.id="TS_12";
t.device="TemperatureSensor";
t.location="Kitchen";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.102";
t.EOJ="001101";
t.EPC="";
t.Command="";
VALUE.Add("TS_12", t);

t = new st_sensor();
t.id="HS_12";
t.device="HumiditySensor_12";
t.location="Kitchen";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.102";
t.EOJ="001201";
t.EPC="";
t.Command="";
VALUE.Add("HS_12", t);

t = new st_sensor();
t.id="D_13";
t.device="Door_13";
t.location="LivingRoom";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.2.151";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_13", t);

t = new st_sensor();
t.id="L_131";
t.device="Light_13";
t.location="LivingRoom";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.2.126";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_131", t);

t = new st_sensor();
t.id="L_132";
t.device="Light_13";
t.location="LivingRoom";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.2.127";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_132", t);

t = new st_sensor();
t.id="TV_13";
t.device="TV_13";
t.location="LivingRoom";
t.init_value="OFF";
t.Type="TV";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("TV_13", t);

t = new st_sensor();
t.id="R_13";
t.device="Radio_13";
t.location="LivingRoom";
t.init_value="OFF";
t.Type="RADIO";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("R_13", t);

t = new st_sensor();
t.id="A_13";
t.device="Airconditioner13";
t.location="LivingRoom";
t.init_value="OFF";
t.Type="AIRCONDITIONER";
t.Active="";
t.IP="192.168.2.170";
t.EOJ="013001";
t.EPC="0x80";
t.Command="";
VALUE.Add("A_13", t);

t = new st_sensor();
t.id="W_131";
t.device="Window_13";
t.location="LivingRoom";
t.init_value="Closed";
t.Type="WINDOW";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("W_131", t);

t = new st_sensor();
t.id="W_132";
t.device="Window_13";
t.location="LivingRoom";
t.init_value="Closed";
t.Type="WINDOW";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("W_132", t);

t = new st_sensor();
t.id="C_131";
t.device="Curtain_13";
t.location="LivingRoom";
t.init_value="Closed";
t.Type="CURTAIN";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("C_131", t);

t = new st_sensor();
t.id="C_132";
t.device="Curtain_13";
t.location="LivingRoom";
t.init_value="Closed";
t.Type="CURTAIN";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("C_132", t);

t = new st_sensor();
t.id="TS_13";
t.device="TemperatureSensor_13";
t.location="LivingRoom";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.103";
t.EOJ="001101";
t.EPC="";
t.Command="";
VALUE.Add("TS_13", t);

t = new st_sensor();
t.id="HS_13";
t.device="HumiditySensor_13";
t.location="LivingRoom";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.103";
t.EOJ="001201";
t.EPC="";
t.Command="";
VALUE.Add("HS_13", t);

t = new st_sensor();
t.id="D_14";
t.device="Door_14";
t.location="Toilet";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.2.152";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_14", t);

t = new st_sensor();
t.id="WS_14";
t.device="WaterFlowSensor14";
t.location="Toilet";
t.init_value="OFF";
t.Type="WATER_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("WS_14", t);

t = new st_sensor();
t.id="L_14";
t.device="Light_14";
t.location="Toilet";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.3.102";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_14", t);

t = new st_sensor();
t.id="T_14";
t.device="Toilet_seat_14";
t.location="Toilet";
t.init_value="ON";
t.Type="TOILET_SEAT";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("T_14", t);

t = new st_sensor();
t.id="VF_14";
t.device="ventilation fan_14";
t.location="Toilet";
t.init_value="OFF";
t.Type="VENTILATION_FAN";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("VF_14", t);

t = new st_sensor();
t.id="D_15";
t.device="Door_15";
t.location="WashRoom";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.3.110";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_15", t);

t = new st_sensor();
t.id="WM_15";
t.device="WashingMachine15";
t.location="WashRoom";
t.init_value="OFF";
t.Type="WASHING_MACHINE";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("WM_15", t);

t = new st_sensor();
t.id="CL_15";
t.device="Closet_15";
t.location="WashRoom";
t.init_value="Closed";
t.Type="CLOSET_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("CL_15", t);

t = new st_sensor();
t.id="HS_15";
t.device="HumiditySensor_12";
t.location="WashRoom";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.101";
t.EOJ="001201";
t.EPC="";
t.Command="";
VALUE.Add("HS_15", t);

t = new st_sensor();
t.id="TS_15";
t.device="TemperatureSensor_15";
t.location="WashRoom";
t.init_value="";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.101";
t.EOJ="001101";
t.EPC="";
t.Command="";
VALUE.Add("TS_15", t);

t = new st_sensor();
t.id="L_15";
t.device="Light_15";
t.location="WashRoom";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.3.101";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_15", t);

t = new st_sensor();
t.id="D_16";
t.device="Door_16";
t.location="BathRoom";
t.init_value="OFF";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.3.111";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_16", t);

t = new st_sensor();
t.id="L_16";
t.device="Light_16";
t.location="BathRoom";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.3.100";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_16", t);

t = new st_sensor();
t.id="VF_16";
t.device="ventilation fan_16";
t.location="BathRoom";
t.init_value="OFF";
t.Type="VENTILATION_FAN";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("VF_16", t);

t = new st_sensor();
t.id="WS_16";
t.device="WaterFlowSensor16";
t.location="BathRoom";
t.init_value="OFF";
t.Type="WATER_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("WS_16", t);

t = new st_sensor();
t.id="HS_17";
t.device="HumiditySensor_17";
t.location="Bedroom1";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.104";
t.EOJ="001201";
t.EPC="";
t.Command="";
VALUE.Add("HS_17", t);

t = new st_sensor();
t.id="TS_17";
t.device="TemperatureSensor_17";
t.location="Bedroom1";
t.init_value="ON";
t.Type="THERMOSTAT";
t.Active="";
t.IP="192.168.2.104";
t.EOJ="001101";
t.EPC="";
t.Command="";
VALUE.Add("TS_17", t);

t = new st_sensor();
t.id="D_17";
t.device="Door_17";
t.location="Bedroom1";
t.init_value="Closed";
t.Type="DOOR_SENSOR";
t.Active="";
t.IP="192.168.3.112";
t.EOJ="05fd01";
t.EPC="0x80";
t.Command="";
VALUE.Add("D_17", t);

t = new st_sensor();
t.id="CL_172";
t.device="Closet_17Door";
t.location="Bedroom1";
t.init_value="CLosed";
t.Type="CLOSET_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("CL_172", t);

t = new st_sensor();
t.id="CL_171";
t.device="Closet_17Door";
t.location="Bedroom1";
t.init_value="CLosed";
t.Type="CLOSET_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("CL_171", t);

t = new st_sensor();
t.id="A_17";
t.device="Airconditioner17";
t.location="Bedroom1";
t.init_value="OFF";
t.Type="AIRCONDITIONER";
t.Active="";
t.IP="192.168.2.171";
t.EOJ="013001";
t.EPC="";
t.Command="";
VALUE.Add("A_17", t);

t = new st_sensor();
t.id="BP_17";
t.device="BedPresensensor17";
t.location="Bedroom1";
t.init_value="OFF";
t.Type="PRESENT_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("BP_17", t);

t = new st_sensor();
t.id="L_17";
t.device="Light_17";
t.location="Bedroom1";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.2.128";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_17", t);

t = new st_sensor();
t.id="L_18";
t.device="Stair_Light";
t.location="Entrance";
t.init_value="OFF";
t.Type="LIGHT";
t.Active="";
t.IP="192.168.2.124";
t.EOJ="029001";
t.EPC="";
t.Command="";
VALUE.Add("L_18", t);

t = new st_sensor();
t.id="MS_21";
t.device="PassageSensor_21";
t.location="Entrance2";
t.init_value="NO";
t.Type="MOTION_SENSOR";
t.Active="";
t.IP="";
t.EOJ="";
t.EPC="";
t.Command="";
VALUE.Add("MS_21", t);
}
public static st_sensor getst_sensorByID(string id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
