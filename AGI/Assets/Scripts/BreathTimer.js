﻿#pragma strict

var timer : float = 180.0;

function Update()
{
	timer -= Time.deltaTime;
}

function OnGUI()
{
	GUI.Box(new Rect(10,10,30,30), timer.ToString("0"));
}