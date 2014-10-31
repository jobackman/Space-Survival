using UnityEngine;
using System.Collections;
using System.IO;



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
	public bool dead;

	//LOG
	Log log;
	public bool logdead;
	string  textfile = @"userdata.txt";


	void Start(){
		wiicontroller = GetComponent<WiiController> ();
		simplecontroller = GetComponent<SimpleController> ();
		wiidblcontroller = GetComponent<WiiDoubleCtrl> ();
		mouselookmod = gameObject.GetComponentInChildren<MouseLookMod> ();
		thrustersound = GameObject.Find("Thrusters").GetComponent<ThrusterSound>();
		totTime = timer;


		logdead = false;

		//InvokeRepeating ("logPlayer", 1f, 1f);
		//dead = false;
		log = GetComponent<Log> ();
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


			//PROBLEM HÄR!! BARA LOGGA EN GÅNG ANNARS KNAOUZ
			logdead=true;
			//dead=true;
		}
	}

//	void logPlayer(){
//		//THE USER DIED, ENTER \N 
//		if(logsession){
//			using (StreamWriter sw = new StreamWriter (textfile, true)) {
//				print ("PLAYER DIED, LOGGING player");
//				sw.WriteLine (log.logText + "\n");
//			}
//		}
//		logsession=false;
//	}


}