using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {

	public int amount;
	public GameObject asteroid1;
	public GameObject asteroid2;
	public GameObject asteroid3;
	public GameObject asteroid4;
	public float fieldRadius;
	public float maxSize;
	public float maxSpeed;
	public float maxRotationSpeed;
	

	// Use this for initialization
	void Start () {

		// OLD INEFFECTIVE METHOD
		for(int i = 0; i < amount; ++i)
		{	
			//Instantiate a new asteroid #1
			GameObject roid1 = (GameObject)Instantiate(asteroid1, Random.insideUnitSphere * fieldRadius, Random.rotation);

			// Randomize velocity, rotationspeed and size
			float size1 = Random.Range(0.05f, maxSize);
			roid1.transform.localScale = Vector3.one * size1;
			roid1.rigidbody.mass *= size1;
			roid1.rigidbody.velocity = Random.insideUnitSphere * Random.Range(0,maxSpeed);
			roid1.rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (0,maxRotationSpeed); 

			//Instantiate #2
			GameObject roid2 = (GameObject)Instantiate(asteroid2, Random.insideUnitSphere * fieldRadius, Random.rotation);
			float size2 = Random.Range(0.05f, maxSize);
			roid2.transform.localScale = Vector3.one * size2;
			roid2.rigidbody.mass *= size2;
			roid2.rigidbody.velocity = Random.insideUnitSphere * Random.Range(0,maxSpeed);
			roid2.rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (0,maxRotationSpeed);

			//Instantiate #3
			GameObject roid3 = (GameObject)Instantiate(asteroid3, Random.insideUnitSphere * fieldRadius, Random.rotation);
			float size3 = Random.Range(0.05f, maxSize);
			roid3.transform.localScale = Vector3.one * size3;
			roid3.rigidbody.mass *= size3;
			roid3.rigidbody.velocity = Random.insideUnitSphere * Random.Range(0,maxSpeed);
			roid3.rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (0,maxRotationSpeed);

			//Instantiate #4
			GameObject roid4 = (GameObject)Instantiate(asteroid4, Random.insideUnitSphere * fieldRadius, Random.rotation);
			float size4 = Random.Range(0.05f, maxSize);
			roid4.transform.localScale = Vector3.one * size4;
			roid4.rigidbody.mass *= size4;
			roid4.rigidbody.velocity = Random.insideUnitSphere * Random.Range(0,maxSpeed);
			roid4.rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (0,maxRotationSpeed);
		}
	}
}
