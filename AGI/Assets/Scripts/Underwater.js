#pragma strict

public var waterLevel : float;
private var isUnderwater : boolean;
private var normalColor : Color;
private var underwaterColor : Color;

public var UWDensity : float = 0.05f;
public var AWDensity : float = 0.005f;

private var chMotor : CharacterMotor;

var myParticles : ParticleSystem;

public var UWSound : AudioSource;
public var AWSound : AudioSource;


function Start () {
	normalColor = new Color(0.5f,0.5f,0.5f,0.5f);
	underwaterColor = new Color(0.22f,0.65f,0.77f,0.5f);
	chMotor = GetComponent(CharacterMotor);
	myParticles.Stop();
	AWSound.Play();
	UWSound.Stop();
}

function Update () {
	if((transform.position.y < waterLevel) != isUnderwater)
	{
	
	isUnderwater = transform.position.y < waterLevel;
	if (isUnderwater) SetUnderwater();
	if (!isUnderwater) SetNormal();
	}
	if(isUnderwater && Input.GetKey(KeyCode.E)){
		constantForce.relativeForce = Vector3(0,-200,0);
	}
	else{
	constantForce.relativeForce = Vector3(0,0,0);
	}
	if(isUnderwater && Input.GetKey(KeyCode.Q)){
		constantForce.relativeForce = Vector3(0,200,0);
	}
	Debug.Log(isUnderwater);
}

function SetNormal ()
{
	RenderSettings.fogColor = normalColor;
	RenderSettings.fogDensity = AWDensity;
	chMotor.movement.gravity = 20;
	chMotor.movement.maxFallSpeed = 20;
	chMotor.movement.maxForwardSpeed = 6;
	chMotor.movement.maxSidewaysSpeed = 6;
	UWSound.Stop();
	AWSound.Play();
}

function SetUnderwater (){
	RenderSettings.fogColor = underwaterColor;
	RenderSettings.fogDensity = UWDensity;
	chMotor.movement.gravity = 2;
	chMotor.movement.maxFallSpeed = 5;
	chMotor.movement.maxForwardSpeed = 4;
	chMotor.movement.maxSidewaysSpeed = 4;
	myParticles.Play();
	UWSound.Play();
	AWSound.Stop();
}