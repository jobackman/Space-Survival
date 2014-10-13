using UnityEngine;
using System.Collections;

public class UpdateMeter : MonoBehaviour {

	public GameObject oxygenmeter;
	public GameObject fuelmeter;
	public GameObject tracking;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Scale bar-size to percent remanaining fuel/oxygen.
		float o2 = tracking.GetComponent<BreathTimer> ().percent;
		float fuel = tracking.GetComponent<WiiController>().percent;
		oxygenmeter.transform.localScale = new Vector3 (o2/100,1,1);
		fuelmeter.transform.localScale = new Vector3 (fuel/100, 1, 1);
	}
}