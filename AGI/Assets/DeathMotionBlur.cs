using UnityEngine;
using System.Collections;

public class DeathMotionBlur : MonoBehaviour {
	float timeLeftFromTimerScript;
	bool CameraMB = false;
	MotionBlur motionblur;
	// Use this for initialization
	void Start () {
		motionblur = GetComponent<MotionBlur>();

	}
	
	// Update is called once per frame
	void Update () {

		timeLeftFromTimerScript = GameObject.Find ("Player").GetComponent<BreathTimer> ().timer;

		if (timeLeftFromTimerScript <= 10) {
			motionblur.blurAmount += Time.deltaTime / 10;	}

		}
	}

