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
	
	void Start(){
		wiicontroller = GetComponent<WiiController> ();
		simplecontroller = GetComponent<SimpleController> ();
		mouselookmod = gameObject.GetComponentInChildren<MouseLookMod> ();
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
			//simplecontroller.enabled = false;
			//mouselookmod.enabled = false;
			

		}
	}
}