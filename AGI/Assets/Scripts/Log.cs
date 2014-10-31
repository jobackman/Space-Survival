using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;

public class Log : MonoBehaviour {
	public GameObject player;
	private float x, y, z, alfa, beta, gamma, time; 
	private bool timeToLog;
	//private StreamWriter sw;

	string  textfile = @"userdata.txt";
	public bool alive;
	WinCollision wincollision;

	public string logText;
	//bool playerWin, playerDead;
	bool logged;
	int fuel;
	float oxygen;
	WiiController wiicontroller;
	BreathTimer breathtimer;
	string winlose;

	// Use this for initialization
	void Start () {	
		timeToLog=true;
		player = GameObject.Find ("Player");
		InvokeRepeating ("logPlayer", 1f, 2f);

		wincollision = GetComponent<WinCollision> ();
		breathtimer = GetComponent<BreathTimer> ();
		logged = false;
		wiicontroller = GetComponent<WiiController> ();
	}

	void Update(){
	}
	
	void logPlayer(){
		//if(!win.win && !dead.dead){
			x = player.rigidbody.position.x;
			y = player.rigidbody.position.y;
			z = player.rigidbody.position.z;
			
			alfa = player.rigidbody.rotation.x;
			beta = player.rigidbody.rotation.y;
			gamma = player.rigidbody.rotation.z;
			
			//Convert score to int and get the values
			time = breathtimer.timer;
			
			string s1 = x.ToString();
			string s2 = y.ToString();
			string s3 = z.ToString();
			string s4 = alfa.ToString();
			string s5 = beta.ToString();
			string s6 = gamma.ToString();
			string s7 = time.ToString();
			
			logText += s1+";"+s2+";"+s3+";"+s4+";"+s5+";"+s6+";"+s7+"\n";

		if ((wincollision.logwin || breathtimer.logdead) && !logged) {

			if(wincollision.logwin){
				winlose="RESULT: WIN, score: "+wincollision.score;
			}
			if(breathtimer.logdead){
				winlose="RESULT: DEAD, score: 0";
			}

			using (StreamWriter sw = new StreamWriter (textfile, true)) {
				print ("Logging player");
				sw.WriteLine (logText+winlose+"\n");
				logged=true;
			}
		}
	

		//text += s1+";"+s2+";"+s3+";"+s4+";"+s5+";"+s6+";"+s7+"\n";
		//System.IO.File.AppendText(@"C:TEST.txt");
	}

//	TEST - LOGGAS ANTINGEN NÄR MAN DÖR - ELLER NÄR MAN VINNER. DVS I WINCOLLISION ELLER BREATHTIMER	
//	void OnApplicationQuit(){
//		//sw = new StreamWriter(@"C:\Users\stefanetoh\Desktop\TEST.txt", true);
//		using (StreamWriter sw = new StreamWriter (textfile, true)) {
//			print ("Logging player");
//			sw.WriteLine (text);
//		}
//	}
}

