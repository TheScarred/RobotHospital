Shader "Unlit/FillBaterry"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_FillTex("Texture", 2D) = "white"{}
		_amount("Fill",Range(0.0,1.0))=1.0
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

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
			sampler2D _FillTex;
			float _amount;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 back = tex2D(_MainTex, i.uv);
                fixed4 front = tex2D(_FillTex, i.uv);
				fixed4 result;
				UNITY_APPLY_FOG(i.fogCoord, col);
				if (i.uv.y > _amount) {
					result= back;
				}
				else {
					result= lerp(front,front*fixed4(1,0,0,0), 1-_amount);
				}

				return result;

                // apply fog
                
                
            }
            ENDCG
        }
    }
}
