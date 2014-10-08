using UnityEngine;
using System.Collections;

public class CollisionSound : MonoBehaviour {
	public AudioClip Impact;
	public AudioClip Ouch;
	BreathTimer breathtimer;
	float tidkvar;
	public AudioSource brabrabra;

	void Start()
	{ 
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
	
			if (tidkvar <= 1) {
			brabrabra.enabled = true;
				}	
				
							
						
				
	
	}
}


	

