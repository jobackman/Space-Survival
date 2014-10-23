using UnityEngine;
using System.Collections;

public class UpdateMeter : MonoBehaviour {

	public GameObject oxygenmeter;
	public GameObject fuelmeter;
	public GameObject tracking;

	WiiController wiictrl;
	WiiDoubleCtrl wiidblctrl;
	float fuel;
	float o2;
	// Use this for initialization
	void Start () {
		wiictrl = tracking.GetComponent<WiiController> ();
		wiidblctrl = tracking.GetComponent<WiiDoubleCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		// Scale bar-size to percent remanaining fuel/oxygen.
		o2 = tracking.GetComponent<BreathTimer> ().percent;

		if (wiictrl.enabled)
						fuel = wiictrl.percent;
		if (wiidblctrl.enabled)
						fuel = wiidblctrl.percent;

		oxygenmeter.transform.localScale = new Vector3 (o2/100,1,1);
		fuelmeter.transform.localScale = new Vector3 (fuel/100, 1, 1);
	}
}