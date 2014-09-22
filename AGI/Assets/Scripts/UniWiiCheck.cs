using UnityEngine;
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

	public float yaw;
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
				display += "Thruster " + i + " engaged!\n";
							}
		}
		else display = "Press the '1' and '2' buttons on your Wii Remote.";

		// Display which wii-motes are connected
		// Left
		GUI.Label( new Rect(Screen.width*1/4 -100,Screen.height/2 + 100, 500, 30), display);
		// Right
		GUI.Label( new Rect(Screen.width*3/4 -100,Screen.height/2 + 100, 500, 30), display);

		// Display Wii-mote stats
		GUI.Label (new Rect (Screen.width/4 + 100, Screen.height/2+100, 500, 100), stats);
		GUI.Label (new Rect (Screen.width*3/4 + 100, Screen.height/2+100, 500, 100), stats);
	}

	void Update(){

		if (wiimote_count () != 0) {
			roll = wiimote_getRoll(0);
			yaw = wiimote_getYaw(0);
			pitch = wiimote_getPitch(0);

			stats = "Roll: " + roll.ToString() + 
					"\nYaw: " + yaw.ToString() + 
					"\nPitch " + pitch.ToString();
		}

	}

	void Start ()
	{
		wiimote_start();
//		Player = GameObject.Find ("/PlayerCube/");
	}
	
	void OnApplicationQuit() {
		wiimote_stop();
	}
	
}