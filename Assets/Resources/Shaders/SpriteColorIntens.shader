// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SpriteColorIntens" {
	Properties {
		_MainTex ("MainTexure", 2D) = "white" {}
		_IntensRGB ("RGBIntensivity", float) = 1
		_IntensA ("AlphaIntensivity", float) = 1
		_Color ("Color", Color) = (1, 1, 1, 1)
	}
	
	SubShader
	{
			//AlphaTest NotEqual 0.0
			Blend SrcAlpha OneMinusSrcAlpha
			Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			ZWrite off
		Pass
		{

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				sampler2D _MainTex;
				float _IntensRGB;
				float _IntensA;
				float4 _Color;

				struct vertIn
				{
					float4 vertex : POSITION;
					float4 uv : TEXCOORD0;
					float4 color : COLOR;
				};

				struct vertOut
				{
					float4 vertex : SV_POSITION;
					float4 uv : TEXCOORD0;
					float4 color : COLOR;
				};

				vertOut vert(vertIn v)
				{
					vertOut o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					o.color = v.color;
					return o;
				}

				float4 frag(vertOut i) : COLOR
				{

					float4 col = tex2D(_MainTex, i.uv);
					col.rgb = col.rgb * _IntensRGB;
					col.a = col.a * _IntensA;
					return col * i.color * _Color;
				}

			ENDCG
		}
		
	}

	FallBack "Diffuse"
}


