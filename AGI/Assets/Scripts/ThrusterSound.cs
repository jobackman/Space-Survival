using UnityEngine;
using System.Collections;

public class ThrusterSound : MonoBehaviour {

	public AudioClip WN;
	public AudioClip WNfadeOut;
	public AudioSource WNAudioSource;

	void Start () {
			audio.clip = WN;
			WNAudioSource.playOnAwake = true;
			WNAudioSource.enabled = false;
			WNAudioSource.loop = false;

		}

	IEnumerator turnOffWN(){
			WNAudioSource.loop = false;
			audio.PlayOneShot(WNfadeOut);
			yield return new WaitForSeconds(WNfadeOut.length);
			WNAudioSource.enabled = false;
			}

	void Update () {
		 
			if (Input.GetKey(KeyCode.E))
				{
					WNAudioSource.enabled = true;
					WNAudioSource.loop = true;
				}

			
			if (Input.GetKeyUp (KeyCode.E))
				{
					StartCoroutine(turnOffWN());
				}

		}
}
