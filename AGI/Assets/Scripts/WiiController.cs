using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class WiiController : MonoBehaviour {

	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getRoll(int which);
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getPitch(int which);
	
	[DllImport ("UniWii")]
	private static extern float wiimote_getYaw(int which);

	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
	private GameObject player;

	private float yaw;
	private float roll;
	private float pitch;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("/Player/");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(wiimote_count() != 0){

			roll = wiimote_getRoll(0);
			yaw = wiimote_getYaw (0);
			pitch = wiimote_getPitch(0);

			if(wiimote_getButtonA(0) && roll <= -60)
			{
				player.rigidbody.AddRelativeTorque(0f,0f,1f, ForceMode.Impulse);	
			}
			if(wiimote_getButtonA(0) && roll >= 30)
			{
				player.rigidbody.AddRelativeTorque(0f,0f,-1f, ForceMode.Impulse);	
			}
			if (wiimote_getButtonB(0)) 
			{
				player.rigidbody.AddRelativeForce(0f,0f,1f, ForceMode.Impulse);
				//player.rigidbody.AddForceAtPosition(player.transform.forward * 10f, player.transform.position);
			}
			if(wiimote_getButtonA(0) && pitch >= 45)
			{
				player.rigidbody.AddRelativeTorque(1,0f,0f, ForceMode.Impulse);	
			}
			if(wiimote_getButtonA(0) && pitch <= -45)
			{
				player.rigidbody.AddRelativeTorque(-1f,0f,0f, ForceMode.Impulse);	
			}
		}
	}
}
