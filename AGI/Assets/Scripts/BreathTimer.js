#pragma strict

public var timer : float = 180.0;
public var timer3D : GameObject;

function Update()
{
	if(timer >= 0){
		timer -= Time.deltaTime;
		timer3D.GetComponent(TextMesh).text = timer.ToString();

	}
}

function OnGUI()
{
	if(timer < 1){
		var msg ="U DEAD SON! \n Press Backspace to Restart";
		GUI.Label(new Rect(Screen.width*0.20f, Screen.height*0.30f, 200,50), msg);
		GUI.Label(new Rect(Screen.width*0.70f, Screen.height*0.30f, 200,50), msg);
	}
	else{
		//GUI.Label(new Rect(Screen.width*0.25f,Screen.height*0.30f+10,30,30),  timer.ToString("0"));
		//GUI.Label(new Rect(Screen.width*0.75f,Screen.height*0.30f+10,30,30),  timer.ToString("0"));
	}
}