
Shader "BackgroundAnimation"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Delay ("Delay", Float) = 0.25
        _Mask ("Mask", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

       // _StencilComp ("Stencil Comparison", Float) = 8
       // _Stencil ("Stencil ID", Float) = 0
       // _StencilOp ("Stencil Operation", Float) = 0
       // _StencilWriteMask ("Stencil Write Mask", Float) = 255
       // _StencilReadMask ("Stencil Read Mask", Float) = 25

        _ColorMask ("Color Mask", Float) = 15

       // [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        //Stencil
        //{
        ///    Ref [_Stencil]
        ///    Comp [_StencilComp]
       //     Pass [_StencilOp]
        ///    ReadMask [_StencilReadMask]
        //    WriteMask [_StencilWriteMask]
        //}

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusDstAlpha
       // ColorMask [_ColorMask]

        Pass
        {
            Name "Default"
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"
            #include "UnityUI.cginc"

            #pragma multi_compile __ UNITY_UI_CLIP_RECT
            //#pragma multi_compile __ UNITY_UI_ALPHACLIP
            #pragma multi_compile _ ETC1_EXTERNAL_ALPHA

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            float _Delay;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.texcoord = v.texcoord;

                OUT.color = v.color * _Color;
                return OUT;
            }

            sampler2D _MainTex;
            sampler2D _Mask;

            fixed4 frag(v2f IN) : SV_Target
            {
                half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;
                half4 maskc = (tex2D(_Mask, IN.texcoord) + _TextureSampleAdd);

                #ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip (color.a - 0.001);
                #endif

				float t = fmod(5*_Time,1 + 2*_Delay)-_Delay;
				float tg = fmod(7*_Time,1 + 2*_Delay)-_Delay;
				float tb = fmod(10*_Time,1 + 2*_Delay)-_Delay;
				if((color.a == 0 && maskc.a == 0) || maskc.r == 0 && maskc.g == 0 && maskc.b == 0){
					return half4(0,0,0,0);
				}

				if(maskc.r != 0)
					color.a *= 1-abs(t-maskc.r)*5;
					
				if(maskc.g != 0)
					color.a *= 1-abs(tg-maskc.g)*5;
					
				if(maskc.b != 0)
					color.a *= 1-abs(tb-maskc.b)*5;

				color.r *= color.a;
				color.g *= color.a;
				color.b *= color.a;
				
                return fixed4(maskc.r,maskc.g,maskc.b,1);
				return color;
            }
        ENDCG
        }
    }
}
