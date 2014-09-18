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

	GameObject backLeftThruster;
	GameObject backRightThruster;
	GameObject centreLeftThruster;
	GameObject centreRightThruster;
	GameObject sideLeftThruster;
	GameObject sideRightThruster; 
	

	void Update(){
		byte accX = wiimote_getAccX(0); // 0 => wiimote nr 0. 
		byte accY = wiimote_getAccY(0);
		byte accZ = wiimote_getAccZ(0);

		float roll = wiimote_getRoll(0);
		float pitch = wiimote_getPitch (0);
		float yaw = wiimote_getYaw (0);

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
			print ("Höger: " + buttonRight);

			centreRightThruster = GameObject.Find("Cylinder-Centre-Right");

			centreRightThruster.rigidbody.AddForceAtPosition(centreRightThruster.transform.up * 0.1f, centreRightThruster.transform.position);
			//rigidbody.AddRelativeForce(0,0,0.1f,ForceMode.Impulse);
 		}
		if (LEFT || buttonLeft) {
			centreLeftThruster = GameObject.Find("Cylinder-Centre-Left");
			
			centreLeftThruster.rigidbody.AddForceAtPosition(centreLeftThruster.transform.up * 0.1f, centreLeftThruster.transform.position);
		}
	}

	//CUBE2 KOPPLAD TILL WIIMOTE
	private Vector3 oldVec;
//	void FixedUpdate () {
//		bool A = wiimote_getButtonA(0);
//		int c = wiimote_count();
//		if (c>0 && A) {
//			for (int i=0; i<=c-1; i++) {
//				float roll = Mathf.Round(wiimote_getRoll(i));
//				float p = Mathf.Round(wiimote_getPitch(i));
//				float yaw = Mathf.Round(wiimote_getYaw(i));
//				if (!float.IsNaN(roll) && !float.IsNaN(p) && (i==c-1)) {
//					Vector3 vec = new Vector3(p, 0 , -1 * roll);
//					vec = Vector3.Lerp(oldVec, vec, Time.deltaTime * 5);
//					oldVec = vec;
//					GameObject.Find("PlayerCube").transform.eulerAngles = vec;
//				}
//				
//			}
//		}
//	}


//	void Start ()
//	{
//		wiimote_start();
//	}
//	
//	void OnApplicationQuit() {
//		wiimote_stop();
//	}
	
}