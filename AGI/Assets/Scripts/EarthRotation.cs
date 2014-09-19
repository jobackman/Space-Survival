using UnityEngine;
using System.Collections;

public class EarthRotation : MonoBehaviour {
	public GameObject Earth;
	public float RotHastighet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Earth.transform.Rotate (0, RotHastighet*Time.deltaTime/10, 0);
	}
}
