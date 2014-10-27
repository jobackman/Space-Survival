using UnityEngine;
using System.Collections;

public class BreathTimer : MonoBehaviour {
		
	SimpleController simplecontroller;
	WiiController wiicontroller;
	MouseLookMod mouselookmod;
	
	public float timer;
	private float totTime;
	public GameObject oxygenMeter;
	public int percent;
	WiiDoubleCtrl wiidblcontroller; 
	ThrusterSound thrustersound;

	void Start(){
		wiicontroller = GetComponent<WiiController> ();
		simplecontroller = GetComponent<SimpleController> ();
		wiidblcontroller = GetComponent<WiiDoubleCtrl> ();
		mouselookmod = gameObject.GetComponentInChildren<MouseLookMod> ();
		thrustersound = GameObject.Find("Thrusters").GetComponent<ThrusterSound>();
		totTime = timer;
	}

	void Update()
	{
		if(timer >= 0){
			timer -= Time.deltaTime;

			// Update percentage of oxygen left, and print to 3DText
			percent = (int)(timer/totTime * 100);
			oxygenMeter.GetComponent<TextMesh>().text = "OXYGEN: " + percent.ToString() + "%";
		}
	}
	
	void OnGUI()
	{
		if(timer < 1){
			// Disable controls when you die.
			wiicontroller.enabled = false;
			thrustersound.soundOn = false;
			wiidblcontroller.enabled = false;
			//simplecontroller.enabled = false;
			//mouselookmod.enabled = false;
		}
	}
}