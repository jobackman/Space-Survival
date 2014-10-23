using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {


	public GameObject thruster;

	public int numberOfParticles;
	private ParticleSystem.Particle[] points;
	int speed = 10;
	
	void Start () {
		points = new ParticleSystem.Particle[numberOfParticles];

		for (int i = 0; i < numberOfParticles; i++) {
			
			//points[i].position = thrusterPosition;
			points[i].color = Color.blue;
			points[i].size = 10f;
			points[i].velocity = new Vector3(1, 0,0);
			
			print("VELOCITY: " + points[i].velocity);
		}
		particleSystem.SetParticles(points, points.Length);
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 thrusterPosition = thruster.transform.position;

		for (int i = 0; i < numberOfParticles; i++) {
			
			points[i].position *= 100000;
			points[i].velocity *= 100000;
			//points[i].size *=10;

//			points[i].position
		}
	}


}

//class Particle{
//	Vector3 position;
//	Vector3 velocity;
//	Vector3 acceleration;
//	float lifetime; 
//
//	Particle(){
//		velocity = new Vector3 (0,0,1);
//		acceleration = new Vector3(0, 0, 1);
//		lifetime = 5;
//	}
//}
