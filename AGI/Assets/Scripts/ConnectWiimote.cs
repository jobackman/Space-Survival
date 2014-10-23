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

	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
	public float roll;
	public float pitch;
	public bool B;
	public bool A;
	
	private String display;
	private String stats;
	private int w;
	private int w4;
	private int h;
	private int h4;
	public int count;

	void Start ()
	{
		wiimote_start();
		w = (int)(Screen.width);
		h = (int)(Screen.height);
		w4 = (int)(w/4);
		h4 = (int)(h/4);
	}
	
	void OnGUI() {
		count = wiimote_count();
		
		if (count>0) {
			display = "";
			for (int i=0; i<=count-1; i++) {
				roll = wiimote_getRoll(i);
				pitch = wiimote_getPitch(i);
				B = wiimote_getButtonB(i);
				A = wiimote_getButtonA(i);

				
				stats = "Wiimote: " + i.ToString() + 
					"\nRoll: " + roll.ToString() + 
					"\nPitch " + pitch.ToString() +
					"\nA " + A.ToString() +	
					"\nB " + B.ToString();

				GUI.Label (new Rect(w4*(i+1),h4*2,w4,h4*2), stats);
			}
		}
		else display = "Press the '1' and '2' buttons on your Wii Remote.";
		
		//Display INFORMATION TEXT
		GUI.Label (new Rect(w4*2,h4*2,w,h), display);
		
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
