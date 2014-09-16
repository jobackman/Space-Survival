using UnityEngine;
using System.Collections;

public class IKOscar : MonoBehaviour {
	private Animator animator;

	public Transform objToPickUp;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

//	void OnAnimatorIK(int ){
//				float reach = animator.GetFloat ("RightHandReach");
//				animator.SetIKPositionWeight (AvatarIKGoal.RightHand, reach);
//				animator.SetIKPosition (AvatarIKGoal.RightHand, objToPickUp.position);
		}

//}
