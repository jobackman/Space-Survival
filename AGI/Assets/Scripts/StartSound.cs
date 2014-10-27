using UnityEngine;
using System.Collections;

public class StartSound : MonoBehaviour {

	public AudioClip startsound;

	// Use this for initialization
	void Start () {
		audio.PlayOneShot(startsound, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
