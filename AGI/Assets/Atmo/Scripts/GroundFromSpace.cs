using UnityEngine;
using System.Collections;

public class GroundFromSpace : MonoBehaviour {

    public Transform mainCamera;
    public GameObject sunLight;
    private Vector3 sunLightDirection;
    private Color waveLength;
    private Color invWaveLength;
    private float cameraHeight;
    private float cameraHeight2;
    private float outerRadius;
    private float outerRadius2;
    private float innerRadius;
    private float innerRadius2;
    private float ESun;
    private float Kr;
    private float Km;
    private float KrESun;
    private float KmESun;
    private float Kr4PI;
    private float Km4PI;
    private float scale;
    private float scaleDepth;
    private float scaleOverScaleDepth;
    private float samples;
    private float g;
    private float g2;
    private bool debug;
	
	void Start() {
	  sunLightDirection = sunLight.transform.TransformDirection (-Vector3.forward);
	  waveLength = new Color(0.650f, 0.570f, 0.475f, 1);
	  invWaveLength = new Color (pow(waveLength[0],4),pow(waveLength[1],4),pow(waveLength[2],4),1);
	  cameraHeight = mainCamera.position.magnitude;
	  	
		innerRadius = transform.localScale.y; //6371;
		innerRadius2 = innerRadius * innerRadius;
		outerRadius = innerRadius * 1.025f; //6530.28f;
	  	outerRadius2 = outerRadius * outerRadius;

	  ESun = 25;
	  Kr = 0.0025f;
	  Km = 0.0015f;
	  KrESun = Kr * ESun;
	  KmESun = Km * ESun;
	  Kr4PI = Kr * 4.0f * Mathf.PI;
	  Km4PI	= Km * 4.0f * Mathf.PI;
	  scale = 1 / (outerRadius - innerRadius);
	  scaleDepth = 0.25f;
	  scaleOverScaleDepth = scale / scaleDepth;
	  samples = 3;
	  g = -0.95f;
	  g2 = g*g;
	  debug = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {

	  sunLightDirection = sunLight.transform.TransformDirection (-Vector3.forward);
	  cameraHeight = mainCamera.position.magnitude;
	  cameraHeight2 = cameraHeight * cameraHeight;
	  
	  // Pass in variables to the Shader
	  renderer.material.SetVector("_CameraPosition",new Vector4(mainCamera.position[0],mainCamera.position[1],mainCamera.position[2], 0));
	  
	  renderer.material.SetVector("_LightDir", new Vector4(sunLightDirection[0],sunLightDirection[1],sunLightDirection[2],0));
	  renderer.material.SetColor("_InvWaveLength", invWaveLength);
	  renderer.material.SetFloat("_CameraHeight", cameraHeight);
	  renderer.material.SetFloat("_CameraHeight2", cameraHeight2);
	  renderer.material.SetFloat("_OuterRadius", outerRadius);
	  renderer.material.SetFloat("_OuterRadius2", outerRadius2);
	  renderer.material.SetFloat("_InnerRadius", innerRadius);
	  renderer.material.SetFloat("_InnerRadius2", innerRadius2);
	  renderer.material.SetFloat("_KrESun",KrESun);
	  renderer.material.SetFloat("_KmESun",KmESun);
	  renderer.material.SetFloat("_Kr4PI",Kr4PI);
	  renderer.material.SetFloat("_Km4PI",Km4PI);
	  renderer.material.SetFloat("_Scale",scale);
	  renderer.material.SetFloat("_ScaleDepth",scaleDepth);
	  renderer.material.SetFloat("_ScaleOverScaleDepth",scaleOverScaleDepth);
	  renderer.material.SetFloat("_Samples",samples);
	  renderer.material.SetFloat("_G",g);
	  renderer.material.SetFloat("_G2",g2);
	}
		
	float pow(float f, int p) {
	  return 1 / Mathf.Pow(f,p);
	}
}
