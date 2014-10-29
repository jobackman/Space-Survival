using UnityEngine;
using System.Collections;

public class GlasImma : MonoBehaviour {
	public float AndningsHastighet = 2.0f;
	public AudioClip Breath;
	float timer;
	// Use this for initialization
	void Start () {
	
	}

	void OnGUI()
	{
//		Color textureColor = guiTexture.color;
//		textureColor.a = Mathf.Sin(Time.time * AndningsHastighet);
//		guiTexture.color = textureColor;
	}
	// Update is called once per frame
	void Update () {
		timer = Mathf.Sin(Time.time * AndningsHastighet);
		//timer = Mathf.Abs (timer);
		//Debug.Log(timer);
		if (timer >= 0f && timer <= 0.0001f) {
			audio.Play();
		}
	}
}

