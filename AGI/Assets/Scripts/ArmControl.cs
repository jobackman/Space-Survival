using UnityEngine;
using System.Collections;

public class ArmControl : MonoBehaviour {
	// the scary broken arm movements, probably:
	
	public Transform Bone1;
	public float Bone1Control= 0.9f;
	//public Transform Bone2;
	//public float Bone2Control= 0.9f;
	//public Transform Bone3;
	//public float Bone3Control= 0.9f;


	
	
	private Vector3 currentDirection = Vector3.forward;
	
	// animation is applied every frame in between Update() and LateUpdate().
	// doing this in LateUpdate has the effect of blending between
	// our procedural rotation for the arm bones and the pre existing one.
	
	void  LateUpdate (){
		currentDirection.x = Mathf.Clamp(currentDirection.x + Input.GetAxis("Mouse X"), -1, 1);
		currentDirection.y = Mathf.Clamp(currentDirection.y + Input.GetAxis("Mouse Y"), -1, 1);
		currentDirection.z = Mathf.Clamp(currentDirection.z + Input.GetAxis("Mouse ScrollWheel"), -1, 1);
		Quaternion rotation = Quaternion.LookRotation(currentDirection);

		Bone1.localRotation = Quaternion.Slerp(Bone1.localRotation, rotation, Bone1Control);
		//Bone2.localRotation = Quaternion.Slerp (Bone2.localRotation, rotation, Bone1Control);
		//Bone3.localRotation = Quaternion.Slerp (Bone3.localRotation, rotation, Bone1Control);



	}
}
	// but you can make it as complex as you like, as procedural animation often needs to be complicated