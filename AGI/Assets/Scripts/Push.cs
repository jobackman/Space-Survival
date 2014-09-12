// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {
	// this script pushes all rigidbodies that the character touches
	float pushPower= 2.0f;
	Vector3 pushDir; 
	void OnControllerColliderHit ( ControllerColliderHit hit  ){
		Rigidbody body = hit.collider.attachedRigidbody;
		
		// no rigidbody
		if (body == null || body.isKinematic) { return; }
		
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) { return; }
		
		// Calculate push direction from move direction,
		// we only push objects to the sides never up and down
		pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
		
		// If you know how fast your character is trying to move,
		// then you can also multiply the push velocity by that.
		
		// Apply the push
		body.velocity = pushDir * pushPower;
	}
}