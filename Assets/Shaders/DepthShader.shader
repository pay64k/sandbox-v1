Shader "Unlit/DepthShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		//HeightMapFloat("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			//#pragma surface surf Lambert
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 color : COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D HeightMap;

			fixed4 lines(out fixed4 fragColor, in fixed4 fragCoord){
				fixed2 uv = fragCoord.xy / 2;
				fragColor = fixed4(1.0, 1.0, 1.0, 1.0);
				float N = 10.0f;
				if( max(0.0f, (uv.x * N) - floor(uv.x * N)) < 0.1f/N) {
					fragColor = fixed4(0.0, 0.0, 0.0, 1.0);
				}
			}

			fixed4 get_color(float height)
			{
				fixed4 color = fixed4(1.0, 1.0, 1.0, 1.0);

		if (height < 0.00f) { color = fixed4(0.00,0.20,0.40,1.0);}
	else if (height < 0.05f) { color = fixed4(0.07,0.42,0.63,1.0);}
	else if (height < 0.055f) { color = fixed4(0,0,0, 1.0);}
	else if (height < 0.09f) { color = fixed4(0.53,0.81,0.98,1.0);}
	else if (height < 0.12f) { color = fixed4(0.69,0.89,1.00,1.0);}
	else if (height < 0.15f) { color = fixed4(0.00,0.38,0.28,1.0);}
	else if (height < 0.19f) { color = fixed4(0.06,0.48,0.18,1.0);}
	else if (height < 0.21f) { color = fixed4(0.91,0.84,0.49,1.0);}
	else if (height < 0.25f) { color = fixed4(0.63,0.26,0.00,1.0);}
	else if (height < 0.62f) { color = fixed4(0.51,0.12,0.12,1.0);}
	else if (height < 0.70f) { color = fixed4(1.00,1.00,1.00,1.0);}

				return color;

			}
			
			v2f vert(appdata v)
			{
				v2f o;
				//float height = v.vertex.z + 1.0;// 
				float4 vertexws = mul(unity_ObjectToWorld, v.vertex);

				//for( 

				//float height = vertexws.y + tex2Dlod(_MainTex, float4(v.uv + float2(i,j) * float2(1.0/320, 1.0/240), 0, 0)).x;
				float height = vertexws.y + tex2Dlod(_MainTex, float4(v.uv, 0, 0)).x;

				vertexws = float4(vertexws.x, height, vertexws.z , vertexws.w);
				
				o.color = get_color(height);
				//o.color = lines(v.uv);

				o.vertex = mul(UNITY_MATRIX_VP, vertexws);

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = i.color;
			/*	fixed4 col = fixed4(i.uv, 0, 1);*/
				return col;
				//return half4(1.0, 0.0, 0.0, 1.0);
			}

			ENDCG
		}
	}
}
