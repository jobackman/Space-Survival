using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class Thrusters : MonoBehaviour {
	
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

	[DllImport ("UniWii")]
	private static extern float wiimote_getRoll(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getYaw(int which);

	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonA(int which);

	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonB(int which);

	public GameObject Player;

	public GameObject backLeftThruster;
	public GameObject backRightThruster;
	public GameObject centerLeftThruster;
	public GameObject centerRightThruster;
	public GameObject sideLeftThruster;
	public GameObject sideRightThruster; 
	

	void Update(){

		float roll = GetComponent<UniWiiCheck>().roll;
		float pitch = GetComponent<UniWiiCheck>().pitch;
		float yaw = GetComponent<UniWiiCheck>().roll;


		//print ("accX: " + accX + " accY: " + accY + " accZ: " + accZ);
		//print ("Roll: " + roll + " Pitch: " + pitch + " Yaw: " + yaw);

		//Vector3 movement = new Vector3 (accX, accY, accZ);
		//rigidbody.AddForce (movement);

		bool up = Input.GetKey (KeyCode.UpArrow);
		bool down = Input.GetKey (KeyCode.DownArrow);

		float speed = yaw/2;


		//Vector3 movement = new Vector3 (speed*Time.deltaTime, 0, 0);
		//rigidbody.transform.Rotate (movement);		

		//Snabbtest för att se hur det rör sig, med arrow down
		if(down){
			Vector3 move = new Vector3 (-100*Time.deltaTime, 0, 0);
			rigidbody.transform.Rotate (move);	
		}


		bool buttonRight = wiimote_getButtonB (0);
		bool buttonLeft = wiimote_getButtonB (1);

		//ISTÄLLET FÖR WIIMOTE!
		bool LEFT = Input.GetKey (KeyCode.LeftArrow);
		bool RIGHT = Input.GetKey (KeyCode.RightArrow);



		if (RIGHT || buttonRight) {
			print("Höger: " + buttonRight);
			//centerRightThruster.rigidbody.AddForceAtPosition(centerRightThruster.transform.up * 1f, centerRightThruster.transform.position);
			rigidbody.AddRelativeForce(0,0,0.1f,ForceMode.Impulse);
 		}
		if (LEFT || buttonLeft) {
			rigidbody.AddRelativeForce(0,0,0.1f, ForceMode.Impulse);
			//centerLeftThruster.rigidbody.AddForceAtPosition(centerLeftThruster.transform.up * 1f, centerLeftThruster.transform.position);
		}
	}
}