using UnityEngine;
using System.Collections;

public class HelmetGlassScreen : MonoBehaviour {
	public Texture GuiTexture;
	private GUITexture TurnON;
	float X;
	float W;
	
	float Y;
	float H;

	void Start(){
		TurnON = gameObject.GetComponent<GUITexture>();
		TurnON.enabled = true; 
		}

	void OnGUI() {

		W = Screen.width;
		H = Screen.height;

		X = -W / 2;
		Y = -H / 2;
				guiTexture.pixelInset = new Rect (X, Y, W, H);
		}



}
