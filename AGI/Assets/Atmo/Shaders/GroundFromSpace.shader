// Upgrade NOTE: replaced 'glstate.matrix.mvp' with 'UNITY_MATRIX_MVP'

Shader "GroundFromSpace" {
	Properties {
	  _CameraPosition("Camera Position",Vector) = (0,0,0,0)
	  _LightDir("Light Direction",Vector) = (0,0,0,0)
	  _InvWaveLength("Inverse WaveLength",Color) = (0,0,0,0)
	  _CameraHeight("Camera Height",Float) = 0
	  _CameraHeight2("Camera Height2",Float) = 0
	  _OuterRadius("Outer Radius",Float) = 0
	  _OuterRadius2("Outer Radius 2",Float) = 0
	  _InnerRadius("Inner Radius",Float) = 0
	  _InnerRadius2("Inner Radius 2",Float) = 0
	  _KrESun("KrESun",Float) = 0
	  _KmESun("KmESun",Float) = 0
	  _Kr4PI("Kr4PI",Float) = 0
	  _Km4PI("Km4PI",Float) = 0
	  _Scale("Scale",Float) = 0
	  _ScaleDepth("Scale Depth",Float) = 0
	  _ScaleOverScaleDepth("Scale Over Scale Depth",Float) = 0
	  _Samples("Samples",Float) = 0
	  _G("G",Float) = 0
	  _G2("G2",Float) = 0
	}
	SubShader {
      Pass {
      	Cull Back
      	Blend SrcAlpha OneMinusSrcAlpha    
      	
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

float4 _CameraPosition;
float4 _LightDir;
float4 _InvWaveLength;
float _CameraHeight;
float _CameraHeight2;	  
float _OuterRadius;
float _OuterRadius2;	  
float _InnerRadius;
float _InnerRadius2;
float _KrESun;
float _KmESun;
float _Kr4PI;
float _Km4PI;
float _Scale;
float _ScaleDepth;
float _ScaleOverScaleDepth;
float _Samples;
float _G;
float _G2;

struct v2f {
  float4 position : POSITION;
  float3 c0 : COLOR0;
  float3 c1 : COLOR1;
};

float expScale (float cos) {
	float x = 1 - cos;
	return _ScaleDepth * exp(-0.00287 + x*(0.459 + x*(3.83 + x*(-6.80 + x*5.25))));
}

v2f vert (float4 vertex : POSITION) {  
  float3 pos = vertex.xyz;
  float3 ray = pos - _CameraPosition.xyz;
  float far = length(ray);
      
  ray /= far;	

  float B = 2.0 * dot(_CameraPosition.xyz, ray);
  float C = _CameraHeight2 - _OuterRadius2;
  float det = max(0.0, B*B - 4.0 * C);
  float near =  0.5 * (-B - sqrt(det));
  
  float3 start = _CameraPosition.xyz + ray * near;
  far -= near;
  
  float startAngle = dot(ray,start) / _OuterRadius;
  float startDepth = exp ((_InnerRadius - _OuterRadius) / _ScaleDepth);
  float cameraAngle = dot(-ray, pos) / length(pos);
  float lightAngle = dot(_LightDir.xyz, pos) / length(pos);
  float cameraScale = expScale(cameraAngle);
  float lightScale = expScale(lightAngle);
  float cameraOffset = startDepth*cameraScale;
  float temp = (lightScale + cameraScale);
  
  float sampleLength = far / _Samples;
  float scaledLength = sampleLength * _Scale;
  float3 sampleRay = ray * sampleLength;
  float3 samplePoint = start + sampleRay * 0.5;
  
  float3 frontColor = float3(0.0, 0.0, 0.0);
  float3 attenuate;
  
  for(int i=0; i<2; i++) {
    float height = length(samplePoint);
    float depth = exp(_ScaleOverScaleDepth * (_InnerRadius - height));
    float scatter = depth*temp - cameraOffset;
    attenuate = exp(-scatter * (_InvWaveLength.xyz * _Kr4PI + _Km4PI));
    frontColor += attenuate * (depth * scaledLength);
    samplePoint += sampleRay;
  }
  
  v2f OUT; 
  OUT.position = mul(UNITY_MATRIX_MVP, vertex);
  OUT.c0.rgb = frontColor * (_InvWaveLength.xyz * _KrESun + _KmESun);
  OUT.c1.rgb = attenuate;

  return OUT;
}

float4 frag (v2f INPUT) : COLOR {
  float4 fragColor; 
  
  fragColor.xyz = INPUT.c0 + 0.075 * INPUT.c1;
  fragColor.w = fragColor.z;
  return fragColor;	
}

ENDCG	
      }
	} 
	FallBack "None"
}
