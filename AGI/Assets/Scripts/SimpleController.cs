using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SimpleController : MonoBehaviour {
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();
	[DllImport ("UniWii")]
	private static extern void wiimote_start();

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
		    {transform.position += transform.forward * speed;}
		if (Input.GetKey (KeyCode.S))
			{transform.position += -transform.forward * speed;}
		if (Input.GetKey (KeyCode.A)) 
			{transform.Rotate(0,-Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.D))
			{transform.Rotate(0,Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.Backspace)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		if (Input.GetKey (KeyCode.Return)) {
			wiimote_stop();		
			wiimote_start();
		}
		if (Input.GetKey (KeyCode.P)) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}

		if (Input.GetKey (KeyCode.F1)) 
			Application.LoadLevel ("ConnectWii");
		if (Input.GetKey (KeyCode.F2)) 
			Application.LoadLevel ("IntroScene");
		if (Input.GetKey (KeyCode.F3))
			Application.LoadLevel ("Space");

	}
}
