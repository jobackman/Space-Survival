using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class RotateObj : MonoBehaviour {


	//public GameObject Sun;
	public float rotSpeed = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.J)) {transform.Rotate(0,Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.L)) {transform.Rotate(0,-Time.deltaTime*rotSpeed,0);}
		if (Input.GetKey (KeyCode.I)) {transform.Rotate(Time.deltaTime*rotSpeed,0,0);}
		if (Input.GetKey (KeyCode.K)) {transform.Rotate(-Time.deltaTime*rotSpeed,0,0);}
	}
}
