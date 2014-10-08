using UnityEngine;
using System.Collections;

public class BreathTimer : MonoBehaviour {
		
	SimpleController simplecontroller;
	WiiController wiicontroller;
	MouseLookMod mouselookmod;

	public float timer = 180f;
	
	void Start(){
		wiicontroller = GetComponent<WiiController> ();
		simplecontroller = GetComponent<SimpleController> ();
		mouselookmod = gameObject.GetComponentInChildren<MouseLookMod> ();
	}

	void Update()
	{
		if(timer >= 0){
			timer -= Time.deltaTime;
		}
	}
	
	void OnGUI()
	{
		if(timer < 1){
			wiicontroller.enabled = false;
			simplecontroller.enabled = false;
			mouselookmod.enabled = false;
			string msg ="U DEAD SON! \n Press Backspace to Restart";

			GUI.Label(new Rect(Screen.width*0.20f, Screen.height*0.30f, 200,50), msg);
			GUI.Label(new Rect(Screen.width*0.70f, Screen.height*0.30f, 200,50), msg);
		}
		else{
			GUI.Label(new Rect(Screen.width*0.25f,Screen.height*0.30f+10,30,30),  timer.ToString("0"));
			GUI.Label(new Rect(Screen.width*0.75f,Screen.height*0.30f+10,30,30),  timer.ToString("0"));
		}
	}
}