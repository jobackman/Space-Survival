using UnityEngine;
using System.Collections;

public class KrockForce : MonoBehaviour {
	//public Transform objekt;
	GameObject[] spacecrap;
	//Component kraft;
	// Use this for initialization
	void Start () {
		spacecrap = GameObject.FindGameObjectsWithTag ("SpaceCrap");
	}


		
		
		//void OnTriggerEnter(Collider objekt)
		//void OnTriggerEnter(Collider gameObject.FindGameObjectsWithTag("spacecrap")
	void OnTriggerEnter(Collider spacecrap)
		{

			GetComponent<ConstantForce> ().enabled = false;

			

		}




	
	// Update is called once per frame
	void Update () {
	
	}
}
