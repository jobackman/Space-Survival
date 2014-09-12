#pragma strict

var impact : AudioClip;

function OnCollisionEnter (hit : Collision)
{
	if(hit.relativeVelocity.magnitude >= 5)
	{
		audio.PlayOneShot(impact);
	}
}

function OnCollisionStay (hit : Collision)
{
	if(hit.relativeVelocity.magnitude >= 3.5)
	{
		audio.PlayOneShot(impact);
	}
}