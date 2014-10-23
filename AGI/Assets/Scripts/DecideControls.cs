using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class DecideControls : MonoBehaviour {

	[DllImport ("UniWii")]
	private static extern int wiimote_count();

	private int count;

	WiiController wiictrl;
	WiiDoubleCtrl wiidblctrl;

	// Use this for initialization
	void Start () {
		wiictrl = GetComponent<WiiController> ();
		wiidblctrl = GetComponent<WiiDoubleCtrl> ();
	}
	
	// Update is called once per frame
	void Update () {

		count = wiimote_count ();

		if (count < 2) {
			wiictrl.enabled = true;
			wiidblctrl.enabled = false;
		}
		if (count >= 2) {
			wiictrl.enabled = false;
			wiidblctrl.enabled = true;
		}

	}
}
