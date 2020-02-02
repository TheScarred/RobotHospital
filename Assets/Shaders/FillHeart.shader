Shader "Unlit/FillHeart"
{
    Properties
    {
<<<<<<< Updated upstream
        _MainTex ("Texture", 2D) = "white" {}
		_FillTex("Texture", 2D) = "white"{}
		_Mask("Mask",2D)="white"{}
=======
        _MainTex ("Back", 2D) = "white" {}
		_FillTex("Front", 2D) = "white"{}
		_Mask("Mask",2D) = "white"{}
>>>>>>> Stashed changes
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
			sampler2D _Mask;
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
<<<<<<< Updated upstream
                fixed4 m = tex2D(_Mask, i.uv).r;
=======
                fixed m = tex2D(_Mask, i.uv).r;
>>>>>>> Stashed changes
				fixed4 result;
				UNITY_APPLY_FOG(i.fogCoord, col);
				if (i.uv.y > _amount+0.125) {
					result= back;
				}
				else {
<<<<<<< Updated upstream
					result= (back*(1-m))+(lerp(front,front*fixed4(0,0,0,0), 1-_amount)*m);
=======
					result=(back*(1-m))+ lerp(front,front*fixed4(0,0,0,0), 1-_amount)*m;
>>>>>>> Stashed changes
				}

				return result;

                // apply fog
                
                
            }
            ENDCG
        }
    }
}
