using UnityEngine;
using System.Collections;

public class WinCollission : MonoBehaviour {

	public GameObject textfield;
	WiiController wiicontroller;

	void start() {
		wiicontroller = GetComponent<WiiController> ();
	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player")
		{
			// Print time!!
			textfield.GetComponent<TextMesh>().text = 
				"You survived!!\n" +
					"You took " + Time.time.ToString() + "s.";
			wiicontroller.enabled = false;
		}
	}
}
