using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class WiiController : MonoBehaviour {
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
//	[DllImport ("UniWii")]
//	private static extern float wiimote_getRoll(int which);
//	[DllImport ("UniWii")]
//	private static extern float wiimote_getPitch(int which);
//	[DllImport ("UniWii")]
//	private static extern float wiimote_getYaw(int which);
	
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
	
	private float yaw;
	private float roll;
	private float pitch;
	private bool ARight;
	private bool BRight;
	private bool ALeft;
	private bool BLeft;
	private bool nunchuck;
	
	//Backup if no wii
	private bool RIGHT, LEFT;
	
	// Use this for initialization
	void Start () {
		maxfuel = fuel;
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
		
			if (fuel > 0) {
				//ROLL left
				if (ARight && roll <= -60) {

					sideRightThruster.rigidbody.AddForceAtPosition (sideRightThruster.transform.up * force, sideRightThruster.transform.position);
					sideLeftThruster.rigidbody.AddForceAtPosition (-sideLeftThruster.transform.up * force, sideLeftThruster.transform.position);

					fuel = fuel - 1;
				}
				//ROLL right
				if (ARight && roll >= 30) {

					sideLeftThruster.rigidbody.AddForceAtPosition (sideLeftThruster.transform.up * force, sideLeftThruster.transform.position);
					sideRightThruster.rigidbody.AddForceAtPosition (-sideRightThruster.transform.up * force, sideRightThruster.transform.position);

					fuel = fuel - 1;
				}

				//Right thruster only
				if (BRight & ! nunchuck) {

					centerLeftThruster.rigidbody.AddForceAtPosition (-centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
					centerRightThruster.rigidbody.AddForceAtPosition (centerRightThruster.transform.up * force, centerRightThruster.transform.position);
					
					fuel = fuel - 1;
				}
				// Left thruster only
				if (nunchuck & ! BRight) {

					centerLeftThruster.rigidbody.AddForceAtPosition (centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
					centerRightThruster.rigidbody.AddForceAtPosition (-centerRightThruster.transform.up * force, centerRightThruster.transform.position);
					
					fuel = fuel - 1;
				}
				// Both thrusters FORWARD WE GO
				if (BRight && nunchuck) {
					centerLeftThruster.rigidbody.AddForceAtPosition (centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
					centerRightThruster.rigidbody.AddForceAtPosition (centerRightThruster.transform.up * force, centerRightThruster.transform.position);
					
					fuel = fuel - 1;
				}


					//PITCH forward
				if (ARight && pitch >= 30 || Input.GetKey(KeyCode.UpArrow)) {
					backLeftThruster.rigidbody.AddForceAtPosition (backLeftThruster.transform.up * force, backLeftThruster.transform.position);
					backRightThruster.rigidbody.AddForceAtPosition (-backRightThruster.transform.up * force, backRightThruster.transform.position);
					fuel = fuel - 1;
				}

					//PITCH backwards
				if (ARight && pitch <= -45 || Input.GetKey(KeyCode.DownArrow)) {
	
					backLeftThruster.rigidbody.AddForceAtPosition (-backLeftThruster.transform.up * force, backLeftThruster.transform.position);
					backRightThruster.rigidbody.AddForceAtPosition (backRightThruster.transform.up * force, backRightThruster.transform.position);	
					fuel = fuel - 1;
				}
			}

			//Update fuelMeter size value;
			percent = (fuel/maxfuel)*100;
		}
	}
	
	void OnGUI()
	{
		//Update fuelMeter text value
		fuelMeter.GetComponent<TextMesh>().text = fuel.ToString();
	}
}
