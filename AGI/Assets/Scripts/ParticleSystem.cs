using UnityEngine;
using System.Collections;

public class ParticleSystem : MonoBehaviour {


	public GameObject thruster;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//The position of the thruster, i.e. where to add the particles
		Vector3 position = thruster.transform.position;
	}
}

class Particle{
	Vector3 position;
	Vector3 velocity;
	Vector3 acceleration;
	float lifetime; 

	Particle(){
		velocity = new Vector3 (0,0,1);
		acceleration = new Vector3(0, 0, 1);
		lifetime = 5;
	}
}
