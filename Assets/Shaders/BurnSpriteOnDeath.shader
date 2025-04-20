Shader "Unlit/BurnSpriteOnDeath"
{
   Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _BurnTex ("Burn Texture", 2D) = "white" {}
        _BurnAmount ("Burn Amount", Range(0, 1)) = 0
        _EdgeColor ("Edge Color", Color) = (1, 0.5, 0, 1)
        _EdgeThickness ("Edge Thickness", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        LOD 100
        
        Cull Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag    
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _BurnTex;
            float4 _MainTex_ST;
            float4 _BurnTex_ST;
            float _BurnAmount;
            float4 _EdgeColor;
            float _EdgeThickness;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;               
                float4 vertex : SV_POSITION;
            };
       
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                               
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
             
                float2 burnUV = TRANSFORM_TEX(uv, _BurnTex);
                
                fixed4 col = tex2D(_MainTex, uv);
                float burn = tex2D(_BurnTex, uv).r;
                

                if (burn < _BurnAmount)
                    discard;

                if (burn < _BurnAmount + _EdgeThickness)
                {
                    col.rgb = _EdgeColor.rgb;
                    col.a = 1;
                }

                return col;
            }
            ENDCG
        }
    }
}
