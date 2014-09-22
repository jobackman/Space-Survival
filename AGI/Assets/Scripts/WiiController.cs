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
	private static extern float wiimote_getRoll(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);
	[DllImport ("UniWii")]
	private static extern float wiimote_getYaw(int which);
	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	public GameObject player;
	public GameObject backLeftThruster;
	public GameObject backRightThruster;
	public GameObject centerLeftThruster;
	public GameObject centerRightThruster;
	public GameObject sideLeftThruster;
	public GameObject sideRightThruster; 
	
	private float yaw;
	private float roll;
	private float pitch;
	private float fuel = 10000;
	private bool ARight;
	private bool BRight;
	private bool ALeft;
	private bool BLeft;
	private float force = 10;
	
	// Use this for initialization
	void Start () {
		//player = GameObject.Find("/PlayerCube/");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//when wiimotes fuck up
		//BRight = Input.GetKey(KeyCode.RightArrow);
		//BLeft = Input.GetKey(KeyCode.LeftArrow);
		
		int count = wiimote_count ();
		if(count > 0){
			
			roll = GetComponent<UniWiiCheck>().roll;
			//yaw = GetComponent<UniWiiCheck>().yaw;
			pitch = GetComponent<UniWiiCheck>().pitch;
			
			ARight = wiimote_getButtonA(0);
			BRight = wiimote_getButtonB(0);
			BLeft = wiimote_getButtonB(1);
			
			//ROLL vänster
			if(ARight && roll <= -60)
			{
				//player.rigidbody.AddRelativeTorque(0f,0f,0.1f, ForceMode.Impulse);
				sideRightThruster.rigidbody.AddForceAtPosition(sideRightThruster.transform.up * force, sideRightThruster.transform.position);
				sideLeftThruster.rigidbody.AddForceAtPosition(-sideLeftThruster.transform.up * force, sideLeftThruster.transform.position);
				
				fuel=fuel-1;
			}
			//ROLL höger
			if(ARight && roll >= 30)
			{
				//player.rigidbody.AddRelativeTorque(0f,0f,-0.1f, ForceMode.Impulse);
				sideLeftThruster.rigidbody.AddForceAtPosition(sideLeftThruster.transform.up * force, sideLeftThruster.transform.position);
				sideRightThruster.rigidbody.AddForceAtPosition(-sideRightThruster.transform.up * force, sideRightThruster.transform.position);
				
				fuel=fuel-1;
			}
			
			//SPINN -> B-button
			if (BRight &! BLeft)
			{
				//player.rigidbody.AddRelativeForce(0f,0f,1f, ForceMode.Impulse);
				
				
				centerLeftThruster.rigidbody.AddForceAtPosition(-centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
				centerRightThruster.rigidbody.AddForceAtPosition(centerRightThruster.transform.up * force, centerRightThruster.transform.position);
				fuel=fuel-1;
			}
			if (BLeft &! BRight) 
			{
				//player.rigidbody.AddRelativeForce(0f,0f,1f, ForceMode.Impulse);
				
				centerLeftThruster.rigidbody.AddForceAtPosition(centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
				centerRightThruster.rigidbody.AddForceAtPosition(-centerRightThruster.transform.up * force, centerRightThruster.transform.position);
				fuel=fuel-1;
			}
			if(BRight && BLeft){
				centerLeftThruster.rigidbody.AddForceAtPosition(centerLeftThruster.transform.up * force, centerLeftThruster.transform.position);
				centerRightThruster.rigidbody.AddForceAtPosition(centerRightThruster.transform.up * force, centerRightThruster.transform.position);
				fuel=fuel-1;
			}
			
			
			//PITCH framåt
			if(ARight && pitch >= 45)
			{
				//player.rigidbody.AddRelativeTorque(0.1f,0f,0f, ForceMode.Impulse);	
				backLeftThruster.rigidbody.AddForceAtPosition(backLeftThruster.transform.up * force, backLeftThruster.transform.position);
				backRightThruster.rigidbody.AddForceAtPosition(backRightThruster.transform.up * force, backRightThruster.transform.position);
				fuel=fuel-1;
			}
			
			//PITCH bakåt
			if(ARight && pitch <= -45)
			{
				//player.rigidbody.AddRelativeTorque(-0.1f,0f,0f, ForceMode.Impulse);	
				
				backLeftThruster.rigidbody.AddForceAtPosition(-backLeftThruster.transform.up * force, backLeftThruster.transform.position);
				backRightThruster.rigidbody.AddForceAtPosition(-backRightThruster.transform.up * force, backRightThruster.transform.position);	
				fuel=fuel-1;
			}
		}
	}
	
	void OnGUI()
	{
		GUI.Label( new Rect(Screen.width/4 -50, Screen.height/2 - 100, 500, 100), "Fuel left: " + fuel);
		GUI.Label( new Rect(Screen.width*3/4 -50, Screen.height/2 - 100, 500, 100), "Fuel left: " + fuel);
	}
}
