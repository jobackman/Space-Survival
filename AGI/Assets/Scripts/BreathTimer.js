#pragma strict

var timer : float = 180.0;

function Update()
{
	if(timer >= 0){
		timer -= Time.deltaTime;
	}
}

function OnGUI()
{
	if(timer < 1){
		var msg ="U DEAD SON! \n Press Backspace to Restart";
		GUI.Label(new Rect(Screen.width*1/4-20, Screen.height/2 - 150, 200,50), msg);
		GUI.Label(new Rect(Screen.width*3/4-20, Screen.height/2 - 150, 200,50), msg);
	}
	else{
		GUI.Label(new Rect(Screen.width*1/4 - 20,Screen.height/2 - 150,30,30),  timer.ToString("0"));
		GUI.Label(new Rect(Screen.width*3/4 - 20,Screen.height/2 - 150,30,30),  timer.ToString("0"));
	}
}