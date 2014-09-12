#pragma strict

public var waterLevel : float = 18;
var floatWeight : float = 2;
var bounceDamp : float = 0.05;
var buoyancyCentreOffset : Vector3;

private var forceFactor : float;
private var actionPoint : Vector3;
private var upLift : Vector3;

function Update() {
	actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
	forceFactor = 1f - ((actionPoint.y - waterLevel) / floatWeight);
	
	if(forceFactor > 0f)
		{
		upLift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
		rigidbody.AddForceAtPosition(upLift, actionPoint);
		}

}