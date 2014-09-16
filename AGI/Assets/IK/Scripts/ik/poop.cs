using UnityEngine;
using System.Collections;

public class poop : MonoBehaviour {
	public Animator Anime;
	public Transform riktmarke;

	// Use this for initialization
	void Start () {
		//Anime = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void OnAnimatorIK() {
		float reach = Anime.GetFloat("RightHandReach");
		Anime.SetIKPositionWeight(AvatarIKGoal.LeftHand, reach);
		Anime.SetIKPosition (AvatarIKGoal.LeftHand, riktmarke.position);
	}
	void Update(){
		if (Input.GetKey (KeyCode.K)) {
			float reach = Anime.GetFloat("RightHandReach");
			Anime.SetIKPositionWeight(AvatarIKGoal.LeftHand, reach);
			Anime.SetIKPosition (AvatarIKGoal.LeftHand, riktmarke.position);	}

}
}