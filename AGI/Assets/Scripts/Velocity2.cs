using UnityEngine;
using System.Collections;

public class Velocity2 : MonoBehaviour {
	public Vector3 Hastighet;
	public GameObject Cube1;
	public GameObject Cube2;
	GameObject TwoCube;
	bool krock;
	public GameObject KolliderarObjekt;
	public float LerpValue;
	//GameObject joint;

	void Start () {
		gameObject.rigidbody.velocity = Hastighet;
		//Cube1 = GameObject.Find ("Cube1");
		//Cube2 = GameObject.Find ("Cube2");
		//TwoCube = GameObject.Find ("TwoCube");
		//krock = false;
	}

	void OnTriggerEnter(Collider Cube1 ){
		//krock = true;
		//joint = gameObject.AddComponent<FixedJoint>();
		if (Input.GetKey(KeyCode.Q))
		    {
		Cube2.AddComponent<FixedJoint>().connectedBody = Cube1.rigidbody;
		}

		//TwoCube.transform.position = Vector3.Lerp (Cube1.transform.position, Cube2.transform.position, LerpValue);
		//Cube1.transform.parent = TwoCube.transform;
		//Cube2.transform.parent = TwoCube.transform;
		//Cube1.rigidbody.isKinematic = true;
		//Cube2.rigidbody.isKinematic = true;
		//TwoCube.rigidbody.isKinematic = false;
		//TwoCube.rigidbody.velocity = Cube1.rigidbody.velocity + Cube2.rigidbody.velocity;
		//TwoCube.rigidbody.rotation = Cube1.rigidbody.rotation;
	}

	void FixedUpdate () {
		//if (krock == true) {
			//TwoCube.rigidbody.MoveRotation = Cube1.rigidbody.MoveRotation;
		//		}
		if (Input.GetKeyDown (KeyCode.E))
		    {

			Destroy(Cube2.GetComponent<FixedJoint>());
		}
		if (Cube2.GetComponents<FixedJoint> ().Length > 1) {
			Destroy(Cube2.GetComponent<FixedJoint>());}

	}
}
