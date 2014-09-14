using UnityEngine;
using System.Collections;

public class KrockForcePlayer : MonoBehaviour {
	//public Transform objekt;						//gameObject är det GameObject-typen som skriptet sitter på
	//GameObject[] spacecrap;
	public GameObject spacecrap;
	public GameObject SpaceMan;
	GameObject DubbelObjekt;
	bool inne;
	public bool grab;
	float xpos;
	float ypos;
	float zpos;
	Vector3 xyzpos;
	float xrot;
	float yrot;
	float zrot;
	Quaternion xyzrot;
	//Component kraft;
	// Use this for initialization
	void Start () { 
		//spacecrap = GameObject.FindGameObjectsWithTag ("SpaceCrap");
		DubbelObjekt = GameObject.Find ("Samlad");
		inne = false;
		grab = false;
	}
	 
	//void OnTriggerEnter(Collider objekt)
	//void OnTriggerEnter(Collider gameObject.FindGameObjectsWithTag("spacecrap")
	void OnTriggerEnter(Collider spacecrap)
		{
			GetComponent<ConstantForce> ().enabled = false;
			inne = true;
		if (Input.GetKey (KeyCode.Q)) {
			grab = true;

			DubbelObjekt.transform.position = Vector3.Lerp (SpaceMan.transform.position, spacecrap.transform.position, 1);
			SpaceMan.transform.parent = DubbelObjekt.transform;
			spacecrap.transform.parent = DubbelObjekt.transform;
			SpaceMan.rigidbody.isKinematic = true;
			spacecrap.rigidbody.isKinematic = true;
			DubbelObjekt.rigidbody.isKinematic = false;
			DubbelObjekt.rigidbody.velocity = SpaceMan.rigidbody.velocity + spacecrap.rigidbody.velocity;
		
		}

	
	
	}

	void OnTriggerExit(Collider spacecrap)
		{	
			inne = false;	
			}
	

	// Update is called once per frame
	void Update () {
	//if (grab)
	//	{
	//		xpos = spacecrap.transform.position.x-1;
	//		ypos = spacecrap.transform.position.y-1;
	//		zpos = spacecrap.transform.position.z;
	//		xyzpos = new Vector3(xpos,ypos,zpos);
	//		SpaceMan.rigidbody.position = xyzpos;

	//		xrot = spacecrap.transform.rotation.x;
	//		yrot = spacecrap.transform.rotation.y;
	//		zrot = spacecrap.transform.rotation.z;
	//		xyzrot = Quaternion.Euler(xrot,yrot,zrot);
	//		SpaceMan.rigidbody.rotation = xyzrot;
	
						//SpaceMan.transform.rotation = spacecrap.transform.rotation;
						//SpaceMan.transform.parent = spacecrap.transform;
				}


}
