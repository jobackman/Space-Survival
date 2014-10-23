using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
	public AudioClip Impact;
	public AudioClip Ouch;
	public AudioClip die;
	BreathTimer breathtimer;
	public AudioSource stopbreathing;
	float tidkvar;
	private bool played;

	void Start()
	{ 
		played = false;
	}

 	IEnumerator OnCollisionEnter()
	{
		audio.PlayOneShot(Impact, 1.0f);
		yield return new WaitForSeconds (0.3f);
		audio.PlayOneShot(Ouch, 1.0f);
	}

	void Update()
	{ 
		tidkvar = gameObject.GetComponent<BreathTimer> ().timer;
	
		if (tidkvar < 0.5) 
		{
			stopbreathing.enabled = false;
			if(!played){
				played = true;
				audio.PlayOneShot(die, 1);
			}
			//brabrabra.enabled = true;
		}	
	}
}


	

