using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class WiiController : MonoBehaviour {
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonNunchuckZ(int which);

	public GameObject player;
	public GameObject backLeftThruster;
	public GameObject backRightThruster;
	public GameObject centerLeftThruster;
	public GameObject centerRightThruster;
	public GameObject sideLeftThruster;
	public GameObject sideRightThruster; 

	public float fuel, force, percent;
	private float maxfuel;
	public GameObject fuelMeter;

	public bool keyboardControls;
	
	private float yaw, roll, pitch;
	private bool ARight, BRight, ALeft, BLeft, nunchuck;

	ThrusterSound thrustersound;

	//Backup if no wii
	private bool RIGHT, LEFT;
	
	// Use this for initialization
	void Start () {
		maxfuel = fuel;
		thrustersound = GameObject.Find("Thrusters").GetComponent<ThrusterSound>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		int count = wiimote_count ();
		if (count > 0 || keyboardControls) {
			
			roll = GetComponent<UniWiiCheck> ().roll;
			pitch = GetComponent<UniWiiCheck> ().pitch;

			ARight = wiimote_getButtonA (0);
			BRight = wiimote_getButtonB (0);

			if(Input.GetKey(KeyCode.RightArrow)){ BRight = true;}
			nunchuck = wiimote_getButtonNunchuckZ (0);
			if(Input.GetKey(KeyCode.LeftArrow)){ nunchuck = true;}
			
			//BLeft = wiimote_getButtonB(1); //Buggar ganska ofta. Testar med nunchuck ist. 

			RIGHT = Input.GetKey(KeyCode.RightArrow);
			LEFT = Input.GetKey(KeyCode.LeftArrow);
		
			if (fuel > 0) {
				//ROLL left
				if (ARight && roll <= -60) {
					activateThruster(sideRightThruster, sideLeftThruster, 1, -1);

				}
				//ROLL right
				if (ARight && roll >= 30) {
					activateThruster(sideLeftThruster, sideRightThruster, 1, -1);
				}

				//Right thruster only
				if ((BRight & ! nunchuck) || RIGHT) {
					activateThruster(centerLeftThruster, centerRightThruster, -1, 1);

				}
				// Left thruster only
				if ((nunchuck & ! BRight) || LEFT) {
					activateThruster(centerLeftThruster, centerRightThruster, 1, -1);
				}
				// Both thrusters FORWARD WE GO
				if (BRight && nunchuck) {
					activateThruster(centerLeftThruster, centerRightThruster, 1, 1);
				}

				//PITCH forward
				if (ARight && pitch >= 30 || Input.GetKey(KeyCode.UpArrow)) {
					activateThruster(backLeftThruster, backRightThruster, 1, -1);
				}

				//PITCH backwards
				if (ARight && pitch <= -45 || Input.GetKey(KeyCode.DownArrow)) {
					activateThruster(backLeftThruster, backRightThruster, -1, 1);
				}
			}

			//Update fuelMeter size value;
			percent = (fuel/maxfuel)*100;


			if(!ARight && !BRight && !ALeft && !BLeft && !nunchuck){
				thrustersound.soundOn = false;
			}
		}
	}

	//t1 - thruster1, t2 - thruster2, d1/2 - direction for each thruster
	void activateThruster(GameObject t1, GameObject t2, int d1, int d2){
		t1.rigidbody.AddForceAtPosition (d1*t1.transform.up * force, t1.transform.position);
		t2.rigidbody.AddForceAtPosition (d2*t1.transform.up * force, t2.transform.position);
		fuel -= 1;
		thrustersound.soundOn = true;
	}


	void OnGUI()
	{
		//Update fuelMeter text value
		fuelMeter.GetComponent<TextMesh>().text = "FUEL: " + fuel.ToString();
	}
}
