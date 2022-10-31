﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GlowSprite"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		_Glow("Glow Intensity", Range(1,5)) = 1
		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog{ Mode Off }
			Blend SrcColor One

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

		struct appdata_t
		{
			float4 vertex : POSITION;
			float4 color : COLOR;
			float2 texcoord : TEXCOORD0;
		};

		struct v2f
		{
			float4 vertex : SV_POSITION;
			fixed4 color : COLOR;
			half2 texcoord : TEXCOORD0;
		};

		fixed4 _Color;

		v2f vert(appdata_t IN)
		{
			v2f OUT;
			OUT.vertex = UnityObjectToClipPos(IN.vertex);
			OUT.texcoord = IN.texcoord;
			OUT.color = IN.color * _Color;
			#ifdef PIXELSNAP_ON
			OUT.vertex = UnityPixelSnap(OUT.vertex);
			#endif

			return OUT;
		}

		sampler2D _MainTex;
		float _Glow;

		fixed4 frag(v2f IN) : SV_Target
		{
			fixed4 c = tex2D(_MainTex, IN.texcoord);
			if (c.a >= 0.1) {
				c = c + (IN.color - c) * IN.color.a * c.a;
			}
			c.rgb *= c.a;
			return c * _Glow;
		}
		ENDCG
	}
	}
}
