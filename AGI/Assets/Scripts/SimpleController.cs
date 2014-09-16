using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {
	public GameObject Controller;
	public float speed = 0.4f;
	public float rotSpeed = 40;
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
		//if (Input.GetKey (KeyCode.A)
		//	transform.position += -transform.right * speed;
		//if (Input.GetKey (KeyCode.D)
		//	transform.position += transform.right * speed;

	}
}
