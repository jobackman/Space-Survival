#pragma strict

var timer : float = 180.0;

function Update()
{
	if(timer > 0){
		timer -= Time.deltaTime;
	}
	else{
		var msg ="U DEAD SON! \n Press Backspace to Restart";
		GUI.Box(new Rect(Screen.width*1/4, Screen.height/2, 50,50), msg);
		GUI.Box(new Rect(Screen.width*3/4, Screen.height/2, 50,50), msg);
	}
}

function OnGUI()
{
	GUI.Label(new Rect(Screen.width*1/4 - 20,Screen.height/2 - 150,30,30), timer.ToString("0"));
	GUI.Label(new Rect(Screen.width*3/4 - 20,Screen.height/2 - 150,30,30), timer.ToString("0"));
}