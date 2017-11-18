// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Skybox/CubemapXY" {
Properties {
    _Tint ("Tint Color", Color) = (.5, .5, .5, .5)
    [Gamma] _Exposure ("Exposure", Range(0, 8)) = 1.0
	_RotationX("RotationX", Range(0, 360)) = 0
	_RotationY("RotationY", Range(0, 360)) = 0
	_RotationZ("RotationZ", Range(0, 360)) = 0
	_MipLevel("Blurriness", Range(0, 1)) = 1
    [NoScaleOffset] _Tex ("Cubemap   (HDR)", Cube) = "grey" {}
}

SubShader {
    Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
    Cull Off ZWrite Off

    Pass {

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma target 2.0

        #include "UnityCG.cginc"

		uniform float4x4 _Rotation;
        samplerCUBE _Tex;
        half4 _Tex_HDR;
        half4 _Tint;
        half _Exposure;
        float _RotationX;
		float _RotationY;
		float _RotationZ;
		float _MipLevel;

        float3 RotateAroundYInDegrees (float3 vertex, float degrees)
        {
			degrees = radians(degrees);
			float3x3 rotationMatrix = { float3(1.0,0.0,0.0),
				float3(0.0,cos(degrees),-sin(degrees)),
				float3(0.0,sin(degrees),cos(degrees)) };
			return mul(vertex, rotationMatrix);
        }

		float3 RotateAroundXInDegrees(float angle, float3 vec)
		{
			angle = radians(angle);
			float3x3 rotationMatrix = { float3(1.0,0.0,0.0),
				float3(0.0,cos(angle),-sin(angle)),
				float3(0.0,sin(angle),cos(angle)) };
			return mul(vec, rotationMatrix);
		}

		float3 RotateAroundZInDegrees(float angle, float3 vec)
		{
			angle = radians(angle);
			float3x3 rotationMatrix = { float3(cos(angle),-sin(angle),0.0),
				float3(sin(angle),cos(angle),0.0),
				float3(0.0,0.0,1.0) };
			return mul(vec, rotationMatrix);
		}

        struct appdata_t {
            float4 vertex : POSITION;
            UNITY_VERTEX_INPUT_INSTANCE_ID
        };

        struct v2f {
            float4 vertex : SV_POSITION;
            float3 texcoord : TEXCOORD0;
            UNITY_VERTEX_OUTPUT_STEREO
        };

        v2f vert (appdata_t v)
        {
			v2f o;
			UNITY_SETUP_INSTANCE_ID(v);
			UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
			float3 rotated = RotateAroundYInDegrees(v.vertex, _RotationX);
			rotated = rotated + RotateAroundXInDegrees(_RotationY, v.vertex);
			rotated = rotated + RotateAroundZInDegrees(_RotationZ, v.vertex);

			o.vertex = UnityObjectToClipPos(rotated);

			o.texcoord = v.vertex.xyz;
			return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
			half4 tex = texCUBElod(_Tex, float4(i.texcoord.xyz,  10 * _MipLevel));
            half3 c = DecodeHDR (tex, _Tex_HDR);
            c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;
            c *= _Exposure;
            return half4(c, 1);
        }
        ENDCG
    }
}


Fallback Off

}
