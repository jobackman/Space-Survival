using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class IntroScript : MonoBehaviour {
	[DllImport ("UniWii")]
	private static extern void wiimote_start();
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();

	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getRoll(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getYaw(int which);
	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonNunchuckZ(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getNunchuckPitch(int which);
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getNunchuckRoll(int which);
	[DllImport ("UniWii")]
	private static extern void wiimote_rumble( int which, float duration);
	
	public GameObject player;
	public GameObject backLeftThruster;
	public GameObject backRightThruster;
	public GameObject centerLeftThruster;
	public GameObject centerRightThruster;
	public GameObject sideLeftThruster;
	public GameObject sideRightThruster; 
	public float fuel, force;

	public bool keyboardControls;
	
	private float Rroll, Lroll, Rpitch, Lpitch;
	private bool ARight, BRight, ALeft, BLeft, nunchuck;
	private int count;
	
	//Backup if no wii
	private bool RIGHT, LEFT, UP, DOWN;

	//Movements that need to be finished
	private bool moveLeft, moveRight, moveForward, pitchUp, pitchDown, rollLeft, rollRight;
	public GameObject cameratext; 
	private TextMesh instructions;


	// Use this for initialization
	void Start () {
		//all movements false by default 
		moveLeft = false;
		moveRight = false;
		moveForward = false;
		pitchDown = false;
		pitchUp = false;
		rollLeft = false;
		rollRight = false; 
		instructions = cameratext.GetComponent<TextMesh> ();

		updateText ("Press the right trigger!");
	}
	
	void FixedUpdate () {
		count = wiimote_count ();
		if (count > 0 || keyboardControls) {

//			roll = wiimote_getRoll(0);
//			pitch = wiimote_getPitch(0);
//			ARight = wiimote_getButtonA (0);
//			BRight = wiimote_getButtonB (0);


			Rroll = wiimote_getRoll (0);
			Rpitch = wiimote_getPitch (0);
			ARight = wiimote_getButtonA (0);
			BRight = wiimote_getButtonB (0);
			
			Lroll = wiimote_getRoll (1);
			Lpitch = wiimote_getPitch (1);
			ALeft = wiimote_getButtonA (1);
			BLeft = wiimote_getButtonB (1);


			//NUNCHUCK-BACKUP
			nunchuck = wiimote_getButtonNunchuckZ (0);

			//if no wiimote 
			RIGHT = Input.GetKey(KeyCode.RightArrow);
			LEFT = Input.GetKey(KeyCode.LeftArrow);
			UP = Input.GetKey(KeyCode.UpArrow);
			DOWN = Input.GetKey(KeyCode.DownArrow);

			if (fuel > 0) {
				//Level 1, unlock moveLeft to proceed
				if(!moveLeft && ((BRight || RIGHT) &! (nunchuck || BLeft) )){
					activateThruster(centerLeftThruster, centerRightThruster, -1, 1);
					moveLeft = true;
					updateText("Great! Now press the left trigger!");
				}
				//moveLeft unlocked
				else if(moveLeft && ((BRight || RIGHT) &! (nunchuck || BLeft ))){
					activateThruster(centerLeftThruster, centerRightThruster, -1, 1);
				}

				//Level 2, unlock moveRight to proceed
				if(!moveRight && moveLeft && ((nunchuck || BLeft) &! BRight)){
					activateThruster(centerLeftThruster, centerRightThruster, 1, -1);
					moveRight = true;
					updateText("Nice! Now press both left and right trigger");
				}
				//moveRight unlocked
				else if(moveRight && moveLeft && ((nunchuck || BLeft) & ! BRight)){
					activateThruster(centerLeftThruster, centerRightThruster, 1, -1);
				}

				//Level 3, unlock moveForward to proceed
				if(!moveForward && moveRight && (BRight && (nunchuck || BLeft) || (LEFT && RIGHT))){
					activateThruster(centerLeftThruster, centerRightThruster, 1, 1);
					moveForward = true;
					updateText ("Tilt the wiimotes forward and hold both A buttons");
				}
				//moveForward unlocked
				else if(moveForward && (BRight && (nunchuck || BLeft) || (LEFT && RIGHT))){
					activateThruster(centerLeftThruster, centerRightThruster, 1, 1);
				}
	
				//Level 4, unlock pitchDown to proceed
				if(!pitchDown && moveForward && (ARight && ALeft && Lpitch >= 30 && Rpitch >=30 || DOWN)){
					activateThruster(backLeftThruster, backRightThruster, 1, -1);
					pitchDown = true;
					updateText ("Great! Now do the same thing, but tilt the controllers backwards");
				}
				//pitchDown unlocked
				else if(pitchDown && moveForward && (ARight && ALeft && Lpitch >= 30 && Rpitch >=30|| DOWN)){
					activateThruster(backLeftThruster, backRightThruster, 1, -1);
				}

				//Level 5, unlock pitchUp to proceed 
				if(!pitchUp && pitchDown && (ARight && ALeft && Lpitch <= -45 && Rpitch <= -45 || UP)){
					activateThruster(backLeftThruster, backRightThruster, -1, 1);
					pitchUp = true;
					updateText ("Now try rolling the controllers to the left and press the A-buttons");
				}
				//pitchUp unlocked
				else if(pitchUp && pitchDown && (ARight && ALeft && Lpitch <= -45 && Rpitch <= -45 || UP)){
					activateThruster(backLeftThruster, backRightThruster, -1, 1);
				}

				//Level 6, unlock rollLeft to proceed (NOT AVAILABLE WITH KEYBOARD)
				if(!rollLeft && pitchUp && (ARight && ALeft && Lroll <= -60 && Rroll <= -60)){
					//ROLL left
					activateThruster(sideRightThruster, sideLeftThruster, 1, -1);
					rollLeft = true;
					updateText ("And to the other side as well");
				}
				//rollLeft unlocked
				else if(rollLeft && pitchUp && (ARight && ALeft && Lroll <= -60 && Rroll <= -60)){
					activateThruster(sideRightThruster, sideLeftThruster, 1, -1);
				}

				//Level 7, unlock rollRight to proceed (NOT AVAILABLE WITH KEYBOARD)
				if(!rollRight && rollLeft && (ARight && ALeft && Lroll >= 30 && Rroll >= 30)){
					activateThruster(sideLeftThruster, sideRightThruster, 1, -1);
					rollRight = true;
					updateText ("GREAT! All levels unlocked!");
//					Application.LoadLevel("Space");
				}
				//rollRight unlocked!
				else if(rollRight && rollLeft && (ARight && ALeft && Lroll >= 30 && Rroll >= 30)){
					activateThruster(sideLeftThruster, sideRightThruster, 1, -1);
				}

				//Unlock all levels with space!
				if(Input.GetKey(KeyCode.Space)){
					moveLeft = moveRight = moveForward = pitchDown = pitchUp = rollLeft = rollRight = true;
					updateText ("All levels unlocked");
					Application.LoadLevel("Space");
				}
			} 
		}
	}
	
	void activateThruster(GameObject t1, GameObject t2, int d1, int d2){
		t1.rigidbody.AddForceAtPosition (d1*t1.transform.up * force, t1.transform.position);
		t2.rigidbody.AddForceAtPosition (d2*t1.transform.up * force, t2.transform.position);
		fuel -= 1;
	}

	void updateText(string t){
		instructions.text = t;
	}

	void OnGUI()
	{

	}

	void OnApplicationQuit() {
		wiimote_stop();
	}
}
