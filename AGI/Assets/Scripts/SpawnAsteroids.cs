using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnAsteroids : MonoBehaviour {

	public int amount;
	public List<GameObject> roids;
	public float fieldRadius;
	//public float zOffset;
	public float maxSize;
	public float maxSpeed;
	public float maxRotationSpeed;
	

	// Use this for initialization
	void Start () {
		// Loop through each type of asteroid *amount* times.
		foreach (GameObject r in roids) {
			for (int i = 0; i < amount; ++i) {
				spawn (r);
			}
		}
	}

	void spawn(GameObject roid){

		//Instantiate a new asteroid in a random place within radius, random rotation
		GameObject newroid = (GameObject)Instantiate(roid, Random.insideUnitSphere * fieldRadius + new Vector3(-fieldRadius,0,0), Random.rotation);
		
		// Randomize velocity, rotationspeed and set mass according to scale.
		float size = Random.Range(0.02f, maxSize);
		newroid.transform.localScale = Vector3.one * size;
		newroid.rigidbody.mass *= size;
		newroid.rigidbody.velocity = Random.insideUnitSphere * Random.Range(0,maxSpeed);
		newroid.rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (0,maxRotationSpeed);		
	}
}
