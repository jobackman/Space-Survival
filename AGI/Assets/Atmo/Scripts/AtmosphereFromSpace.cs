using UnityEngine;
using System.Collections;

public class AtmosphereFromSpace : MonoBehaviour {

    public Transform mainCamera;
    public GameObject sunLight;
    public Vector3 sunLightDirection;
    public Color waveLength;
    public Color invWaveLength;
    public float cameraHeight;
    public float cameraHeight2;
    public float outerRadius;
    public float outerRadius2;
    public float innerRadius;
    public float innerRadius2;
    public float ESun;
    public float Kr;
    public float Km;
    public float KrESun;
    public float KmESun;
    public float Kr4PI;
    public float Km4PI;
    public float scale;
    public float scaleDepth;
    public float scaleOverScaleDepth;
    public float samples;
    public float g;
    public float g2;
	
	void Start() {
	    sunLightDirection = sunLight.transform.TransformDirection (-Vector3.forward);
	    waveLength = new Color(0.650f, 0.570f, 0.475f, 0.5f);
	    invWaveLength = new Color (pow(waveLength[0],4),pow(waveLength[1],4),pow(waveLength[2],4),0.5f);
	    cameraHeight = mainCamera.position.magnitude;

	    outerRadius = transform.localScale.y;		//Radius of atmosphere, 2.5% larger than the ground
	    outerRadius2 = outerRadius * outerRadius;
		innerRadius = outerRadius * 0.975f;			//Radius of ground
    	innerRadius2 = innerRadius * innerRadius;

		ESun = 25f;					//Brightness of sun
	    Kr = 0.0025f;				//Rayleigh scattering constant
	    Km = 0.0015f;				//Mie scattering constant
	    KrESun = Kr * ESun;
	    KmESun = Km * ESun;
	    Kr4PI = Kr * 4.0f * Mathf.PI;
	    Km4PI	= Km * 4.0f * Mathf.PI;

	    scale = 1f / (outerRadius - innerRadius);
		scaleDepth = 0.25f;
	    scaleOverScaleDepth = scale / scaleDepth;
		samples = 4f;								
		g = -0.95f;		//Gravity
	    g2 = g*g;
	}


	// Update variables such as cameraposition or sun when it moves
	void LateUpdate () {

	    sunLightDirection = sunLight.transform.TransformDirection (-Vector3.forward);

        invWaveLength = new Color(pow(waveLength[0], 4), pow(waveLength[1], 4), pow(waveLength[2], 4), 0.5f);

        cameraHeight = mainCamera.position.magnitude;
        cameraHeight2 = cameraHeight * cameraHeight;

        outerRadius2 = outerRadius * outerRadius;
        innerRadius2 = innerRadius * innerRadius;
        KrESun = Kr * ESun;
        KmESun = Km * ESun;
        Kr4PI = Kr * 4.0f * Mathf.PI;
        Km4PI = Km * 4.0f * Mathf.PI;
        scale = 1 / (outerRadius - innerRadius);
        scaleOverScaleDepth = scale / scaleDepth;
        g2 = g * g;

	    // Pass variables to Shader
	    renderer.material.SetVector("_v4CameraPos",new Vector4(mainCamera.position[0],mainCamera.position[1],mainCamera.position[2], 0));
	  
	    renderer.material.SetVector("_v4LightDir", new Vector4(sunLightDirection[0],sunLightDirection[1],sunLightDirection[2],0));
	    renderer.material.SetColor("_cInvWaveLength", invWaveLength);
	    renderer.material.SetFloat("_fCameraHeight", cameraHeight);
	    renderer.material.SetFloat("_fCameraHeight2", cameraHeight2);
	    renderer.material.SetFloat("_fOuterRadius", outerRadius);
	    renderer.material.SetFloat("_fOuterRadius2", outerRadius2);
	    renderer.material.SetFloat("_fInnerRadius", innerRadius);
	    renderer.material.SetFloat("_fInnerRadius2", innerRadius2);
	    renderer.material.SetFloat("_fKrESun",KrESun);
	    renderer.material.SetFloat("_fKmESun",KmESun);
	    renderer.material.SetFloat("_fKr4PI",Kr4PI);
	    renderer.material.SetFloat("_fKm4PI",Km4PI);
	    renderer.material.SetFloat("_fScale",scale);
	    renderer.material.SetFloat("_fScaleDepth",scaleDepth);
	    renderer.material.SetFloat("_fScaleOverScaleDepth",scaleOverScaleDepth);
	    renderer.material.SetFloat("_Samples",samples);
	    renderer.material.SetFloat("_G",g);
	    renderer.material.SetFloat("_G2",g2);
	}
	
	float pow(float f, int p) {
	    return 1f / Mathf.Pow(f,p);
	}
}
