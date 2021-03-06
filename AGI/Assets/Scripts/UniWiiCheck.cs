﻿using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class UniWiiCheck : MonoBehaviour {
	
	[DllImport ("UniWii")]
	private static extern void wiimote_start();
	
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();
	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();

	[DllImport ("UniWii")]
	private static extern float wiimote_getRoll(int which);

	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);

	[DllImport ("UniWii")]
	private static extern float wiimote_getYaw(int which);

	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);

	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);


	//public GameObject Player;
	public GameObject wiiHelp;

	//public float yaw;
	public float roll;
	public float pitch;

	private String display;
	private String stats;
	public int count;
	
	void OnGUI() {
		count = wiimote_count();

		if (count>0) {
			display = "";
			for (int i=0; i<=count-1; i++) {
				display = "";
				roll = wiimote_getRoll(0);
				pitch = wiimote_getPitch(0);
				
//				stats = "Roll: " + roll.ToString() + 
//					"\nPitch " + pitch.ToString();

							}
		}
		//else display = "Press the '1' and '2' buttons on your Wii Remote.";

		//Display INFORMATION TEXT
		//wiiHelp.GetComponent<TextMesh> ().text = display;

	}

	void Start ()
	{
		//wiimote_start();
	}
	
	void OnApplicationQuit() {
		wiimote_stop();
	}
	
}