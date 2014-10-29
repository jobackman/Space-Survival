using UnityEngine;
using System.Collections;

public class DistanceTracker : MonoBehaviour {

	public GameObject tracking;
	private float distance;
	private TextMesh textmesh;
	private Vector3 shipPos;
	private Vector3 myPos;

	// Use this for initialization
	void Start () {
		textmesh = GetComponent<TextMesh> ();
		//textmesh.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		shipPos = tracking.transform.position;
		myPos = transform.position;

		distance = (shipPos - myPos).magnitude - 20;
		textmesh.text = distance.ToString("0") + "m";
	}
}
