using UnityEngine;
using System.Collections;

public class ArmMove : MonoBehaviour {
	public Transform target;

	void Update() {
		float xpos = target.position.x;
		if (Input.GetKeyDown (KeyCode.B)) {

			xpos += 1;
			Debug.Log ("B tryckt");
			//transform.position = new Vector3(0,0,0);
		}
		//Vector3 relativePos = target.position - transform.position;
		//Quaternion rotation = Quaternion.LookRotation(relativePos);
		//transform.rotation = rotation;
	}
}