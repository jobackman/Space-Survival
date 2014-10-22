using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class ConnectWiimote : MonoBehaviour {
		
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
	
	public float roll;
	public float pitch;
	
	private String display;
	private String stats;
	private int w;
	private int h;
	public int count;

	void Start ()
	{
		wiimote_start();
		w = (int)(Screen.width / 2);
		h = (int)(Screen.height / 2);
	}
	
	void OnGUI() {
		count = wiimote_count();
		
		if (count>0) {
			display = "";
			for (int i=0; i<=count-1; i++) {
				roll = wiimote_getRoll(0);
				pitch = wiimote_getPitch(0);
				
				stats = "Roll: " + roll.ToString() + 
					"\nPitch " + pitch.ToString();

				display = stats;
			}
		}
		else display = "Press the '1' and '2' buttons on your Wii Remote.";
		
		//Display INFORMATION TEXT
		GUI.Label (new Rect(w,h,w*2,h*2), display);
		
	}
	
	void Update(){

		if (Input.GetKey (KeyCode.Space)) {
			Application.LoadLevel ("Space");
		}
		if (Input.GetKey (KeyCode.Backspace)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (Input.GetKey (KeyCode.Return)) {
			wiimote_stop();		
			wiimote_start();
		}
		
	}
	
	void OnApplicationQuit() {
		wiimote_stop();
	}

}
