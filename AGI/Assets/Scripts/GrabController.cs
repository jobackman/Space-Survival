using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]

public class GrabController : MonoBehaviour {

	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;		// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2

	static int idleState = Animator.StringToHash("Base Layer.ArmsIdle");
	static int RightGrabState = Animator.StringToHash("Layer2.RightHandGrab");
	static int LeftGrabState = Animator.StringToHash("Layer2.LeftHandGrab");


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	//	if(anim.layerCount ==2)
	//		anim.SetLayerWeight(1, 1);
	}


	
	// Update is called once per frame
	void FixedUpdate () {

		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation

		if (currentBaseState.nameHash == idleState)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				anim.SetBool("rightgrab", true);
			}
			if(Input.GetKeyDown(KeyCode.Q))
			{
				anim.SetBool("leftgrab", true);

			}
		}



		// if we enter the waving state, reset the bool to let us wave again in future
		if(layer2CurrentState.nameHash == RightGrabState)
		{
			anim.SetBool ("rightgrab", false);
		}

		if(layer2CurrentState.nameHash == LeftGrabState)
		{
			anim.SetBool("leftgrab", false);
		}
		
//		if (Input.GetKeyDown(KeyCode.Z))
//		{
//			Debug.Log ("rightgrab tryckt");
//			anim.SetBool ("rightgrab", true);
//		}
//		else if (Input.GetKeyDown(KeyCode.Q))
//		{
//			Debug.Log ("leftgrab tryckt");
//			anim.SetBool ("leftgrab", true);
//		}

//		else
//		{
//			anim.SetBool ("rightgrab", false);
//			anim.SetBool ("leftgrab", false);
//		}



	}
}
