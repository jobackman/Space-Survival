using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;

public class Log : MonoBehaviour {
	public GameObject player;
	private float x, y, z, alfa, beta, gamma, t; 
	private bool timeToLog;
	//private StreamWriter sw;
	string text;

	string  textfile = @"userdata.txt";

	// Use this for initialization
	void Start () {	
		timeToLog=true;
		player = GameObject.Find ("Player");
		InvokeRepeating ("logPlayer", 1f, 2f);
	}
	
	void logPlayer(){
		x = player.rigidbody.position.x;
		y = player.rigidbody.position.y;
		z = player.rigidbody.position.z;
		
		alfa = player.rigidbody.rotation.x;
		beta = player.rigidbody.rotation.y;
		gamma = player.rigidbody.rotation.z;
		
		t = Time.time;

		string s1 = x.ToString();
		string s2 = y.ToString();
		string s3 = z.ToString();
		string s4 = alfa.ToString();
		string s5 = beta.ToString();
		string s6 = gamma.ToString();
		string s7 = t.ToString();


		text += s1+";"+s2+";"+s3+";"+s4+";"+s5+";"+s6+";"+s7+"\n";
		//System.IO.File.AppendText(@"C:TEST.txt");
	}

	void OnApplicationQuit(){
		//sw = new StreamWriter(@"C:\Users\stefanetoh\Desktop\TEST.txt", true);
		using (StreamWriter sw = new StreamWriter (textfile, true)) {
			print ("Logging player");
			sw.WriteLine (text);
		}
	}
}

