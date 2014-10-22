using UnityEngine;
using System.Collections;

public class ParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Particle p = new Particle ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

class Particle{
	Vector3 position;
	Vector3 velocity;
	Vector3 acceleration;
	float lifetime; 

	Particle(Vector3 pos){
		position = pos;
		velocity = new Vector3 (0,0,1);
		acceleration = new Vector3(0, 0, 1);
		lifetime = 5;
	}
}
