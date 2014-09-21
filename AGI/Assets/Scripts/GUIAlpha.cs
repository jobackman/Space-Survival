using UnityEngine;
using System.Collections;

public class GUIAlpha : MonoBehaviour {

	public float Transparancy = 0.1f;
	void OnGUI()
	{
		Color textureColor = guiTexture.color;
		textureColor.a = Transparancy;
		
		guiTexture.color = textureColor;
	}
	// Update is called once per frame

}
