using UnityEngine;
using System.Collections;

public class ThrusterSound : MonoBehaviour {

	public AudioClip WN;
	public AudioClip WNfadeOut;
	public AudioSource WNAudioSource;
	public bool soundOn;

	void Start () {
		audio.clip = WN;
		WNAudioSource.playOnAwake = true;
		WNAudioSource.enabled = false;
		WNAudioSource.loop = false;
		soundOn = false;
	}

	IEnumerator turnOffWN(){
		WNAudioSource.loop = false;
		//audio.PlayOneShot(WNfadeOut);
		yield return new WaitForSeconds(WNfadeOut.length-1/WNfadeOut.length);
		WNAudioSource.enabled = false;
	}

	void Update () {
		 
		if(soundOn){
			WNAudioSource.enabled = true;
			WNAudioSource.loop = true;
		}

		
		if(!soundOn){		
			StartCoroutine(turnOffWN());
		}
	}
}
