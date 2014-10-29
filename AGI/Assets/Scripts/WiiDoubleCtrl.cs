using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class WiiDoubleCtrl : MonoBehaviour {
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getRoll(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);

	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonNunchuckZ(int which);
	//	[DllImport ("UniWii")]
	//	private static extern float wiimote_getNunchuckPitch(int which);
	//	
	//	[DllImport ("UniWii")]
	//	private static extern float wiimote_getNunchuckRoll(int which);
	
	
	public GameObject player;
	public GameObject backLeftThruster;
	public GameObject backRightThruster;
	public GameObject centerLeftThruster;
	public GameObject centerRightThruster;
	public GameObject sideLeftThruster;
	public GameObject sideRightThruster; 
	public float fuel;
	private float maxfuel;
	public float percent;
	public GameObject fuelMeter;
	public float force;
	
	public bool keyboardControls;

	private float Rroll;
	private float Lroll;

	private float Rpitch;
	private float Lpitch;

	private bool ARight;
	private bool BRight;
	private bool ALeft;
	private bool BLeft;

	private bool nunchuck;

	ThrusterSound thrustersound;

	// Use this for initialization
	void Start () {
		maxfuel = fuel;
		thrustersound = GameObject.Find("Thrusters").GetComponent<ThrusterSound> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		int count = wiimote_count ();
		if (count > 0 || keyboardControls) {
			
			Rroll = wiimote_getRoll (0);
			Rpitch = wiimote_getPitch (0);
			ARight = wiimote_getButtonA (0);
			BRight = wiimote_getButtonB (0);
			
			Lroll = wiimote_getRoll (1);
			Lpitch = wiimote_getPitch (1);
			ALeft = wiimote_getButtonA (1);
			BLeft = wiimote_getButtonB (1);


			if (fuel > 0) {

			// ################# RIGHT HALF ####################

				//Right thruster only
				if (BRight || Input.GetKey(KeyCode.RightArrow)) {
					activateThruster(centerRightThruster, 1);
				}
				
				//ROLL left
				if (ARight && Rroll <= -60) {
					activateThruster(sideRightThruster, 1);
				}
				//ROLL right
				if (ARight && Rroll >= 30) {
					activateThruster(sideRightThruster, -1);
				}

				//PITCH forward
				if (ARight && Rpitch >= 30 || Input.GetKey(KeyCode.UpArrow)) {
					activateThruster(backRightThruster, -1);
				}
				
				//PITCH backwards
				if (ARight && Rpitch <= -45 || Input.GetKey(KeyCode.DownArrow)) {
					activateThruster(backRightThruster, 1);
				}

			// ####################### LEFT HALF ###########################
				// Left thruster only
				if (BLeft || Input.GetKey(KeyCode.LeftArrow)) {
					activateThruster(centerLeftThruster, 1);	
				}
				
				//ROLL left
				if (ALeft && Lroll <= -60) {
					activateThruster(sideLeftThruster, -1);
				}
				//ROLL right
				if (ALeft && Lroll >= 30) {
					activateThruster(sideLeftThruster, 1);
				}
				
				//PITCH forward
				if (ALeft && Lpitch >= 30 || Input.GetKey(KeyCode.UpArrow)) {
					activateThruster(backLeftThruster, 1);
				}
				
				//PITCH backwards
				if (ALeft && Lpitch <= -45 || Input.GetKey(KeyCode.DownArrow)) {
					activateThruster(backLeftThruster, -1);

				}
			}
			
			//Update fuelMeter size value;
			percent = (fuel/maxfuel)*100;

			if(!ARight && !BRight && !ALeft && !BLeft){
				thrustersound.soundOn = false;
			}

		}
	}

	void activateThruster(GameObject t1, int d1){
		t1.rigidbody.AddForceAtPosition (d1*t1.transform.up * force, t1.transform.position);
		thrustersound.soundOn = true;
		fuel -= 1;
	}
	
	void OnGUI()
	{
		//Update fuelMeter text value
		fuelMeter.GetComponent<TextMesh>().text = "FUEL: " + percent.ToString("0") + "%";
	}
}
