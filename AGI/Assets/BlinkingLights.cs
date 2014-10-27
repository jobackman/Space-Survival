using UnityEngine;
using System.Collections;

public class BlinkingLights : MonoBehaviour {

	public GameObject lights;
	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if ((Time.time % speed) <= speed / 2) {
			lights.SetActive (false);
		} 
		else {
			lights.SetActive(true);
				}
	}
}
