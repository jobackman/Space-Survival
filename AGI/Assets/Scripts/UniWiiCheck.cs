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
	private static extern byte wiimote_getAccX(int which);

	[DllImport ("UniWii")]
	private static extern byte wiimote_getAccY(int which);

	[DllImport ("UniWii")]
	private static extern byte wiimote_getAccZ(int which);

	public GameObject Arm;

	private String display;
	
	void OnGUI() {
		int c = wiimote_count();

		if (c>0) {
			display = "";
			for (int i=0; i<=c-1; i++) {
				display += "Wiimote " + i + " found!\n";
							}
		}
		else display = "Press the '1' and '2' buttons on your Wii Remote.";
		
		GUI.Label( new Rect(10,Screen.height-100, 500, 100), display);
	}

	void Update(){

		if (wiimote_count () != 0) {
				float diffX = wiimote_getAccX(0) -128;
				float diffY = wiimote_getAccY(0) -128;
				float diffZ = wiimote_getAccZ(0) -128 -30;

				Arm = GameObject.Find ("/Cube2/");
				print ("diffX: " + diffX + " diffY: " + diffY + " diffZ: " + diffZ);
			}
		if(Input.GetKey (KeyCode.UpArrow))
		{
			GameObject.Find("/Cube2/Rightarm").rigidbody.AddRelativeForce(0,0,1,ForceMode.Impulse);	
		}
		if(Input.GetKey (KeyCode.DownArrow))
		{
			GameObject.Find("/Cube2/Rightarm").rigidbody.AddRelativeForce(0,0,-1,ForceMode.Impulse);	
		}
	}

	void Start ()
	{
		wiimote_start();
	}
	
	void OnApplicationQuit() {
		wiimote_stop();
	}
	
}