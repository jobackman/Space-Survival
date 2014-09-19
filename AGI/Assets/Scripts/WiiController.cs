using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class WiiController : MonoBehaviour {
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonA(int which);
	
	[DllImport("UniWii")]
	private static extern Boolean wiimote_getButtonB(int which);
	
	public GameObject player;

	private float yaw;
	private float roll;
	private float pitch;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("/PlayerCube/");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.GetComponent<UniWiiCheck>().count != 0){

			roll = player.GetComponent<UniWiiCheck>().roll;
			yaw = player.GetComponent<UniWiiCheck>().yaw;
			pitch = player.GetComponent<UniWiiCheck>().pitch;

			if(wiimote_getButtonA(0) && roll <= -60)
			{
				player.rigidbody.AddRelativeTorque(0f,0f,0.5f, ForceMode.Impulse);	
			}
			if(wiimote_getButtonA(0) && roll >= 30)
			{
				player.rigidbody.AddRelativeTorque(0f,0f,-0.5f, ForceMode.Impulse);	
			}
			if (wiimote_getButtonB(0)) 
			{
				player.rigidbody.AddRelativeForce(0f,0f,0.5f, ForceMode.Impulse);
			}
			if(wiimote_getButtonA(0) && pitch >= 45)
			{
				player.rigidbody.AddRelativeTorque(0.5f,0f,0f, ForceMode.Impulse);	
			}
			if(wiimote_getButtonA(0) && pitch <= -45)
			{
				player.rigidbody.AddRelativeTorque(-0.5f,0f,0f, ForceMode.Impulse);	
			}
		}
	}
}
