﻿#pragma strict

var target : Transform;
var handTransform : Transform;

var shoulderTransform : Transform;
var shoulderElbowPoint : Transform;
var shoulderLength: float;

var wristTransform : Transform;
var wristElbowPoint : Transform;
var wristLength : float;

var elbowWeight : Transform;

var elbow2 : float;
var distToTarget : float;


function Awake () {
	shoulderLength = Vector3.Distance(shoulderTransform.position, shoulderElbowPoint.position);
	wristLength = Vector3.Distance(wristTransform.position, wristElbowPoint.position);
}

function Update () {
	handTransform.rotation = target.rotation;
	handTransform.position = wristTransform.position;
	transform.LookAt(target, transform.position - elbowWeight.position);
	elbow2 = (Mathf.Pow(distToTarget, 2) - Mathf.Pow(wristLength, 2) + Mathf.Pow(shoulderLength,2))/(distToTarget*2);
	
	wristTransform.localPosition.z = Mathf.Clamp(distToTarget, 0, wristLength + shoulderLength);
	
	if (distToTarget < shoulderLength + wristLength &&
	distToTarget > Mathf.Max(shoulderLength, wristLength) - Mathf.Min(shoulderLength, wristLength)){
	shoulderTransform.localRotation = Quaternion.Euler(Mathf.Acos(elbow2/shoulderLength)*Mathf.Rad2Deg, 0, 0);
	wristTransform.localRotation =
	Quaternion.Euler(-(Mathf.Acos((distToTarget - elbow2)/wristLength)*Mathf.Rad2Deg), 0,0);
	}
	
	if (distToTarget >= shoulderLength + wristLength)
	{
		shoulderTransform.localRotation = Quaternion.Euler(0,0,0);
		wristTransform.localRotation = Quaternion.Euler(0,0,0);
		}
		
	if (distToTarget <= Mathf.Max(shoulderLength, wristLength) - Mathf.Min(shoulderLength, wristLength))
	{
		shoulderTransform.localRotation = Quaternion.Euler(0,0,0);
		wristTransform.localRotation = Quaternion.Euler(0,0,0);
		}
	
}