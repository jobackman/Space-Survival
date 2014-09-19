using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SimpleController : MonoBehaviour {
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();
	[DllImport ("UniWii")]
	private static extern void wiimote_start();
	
	public GameObject Controller;
	public float speed = 0.4f;
	public float rotSpeed = 50;
	float yrot;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		yrot = transform.rotation.y;
		if (Input.GetKey (KeyCode.W))
		    {Controller.transform.position += transform.forward * speed;}
		if (Input.GetKey (KeyCode.S))
			{Controller.transform.position += -transform.forward * speed;}
		if (Input.GetKey (KeyCode.A)) 
			{Controller.transform.Rotate(0,-Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.D))
			{Controller.transform.Rotate(0,Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.Backspace)) {
				Application.LoadLevel (Application.loadedLevel);
				wiimote_stop();
			}
		if (Input.GetKey (KeyCode.P)) {
			wiimote_stop();		
			wiimote_start();
		}

	}
}
