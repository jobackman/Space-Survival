using UnityEngine;
using System.Collections;

public class PlanetCameraRotate : MonoBehaviour {
	public Transform PlayerCamera;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = PlayerCamera.transform.rotation;
	}
}
