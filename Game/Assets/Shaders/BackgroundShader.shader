Shader "Custom/MulticolorUIBackgroundShader"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (1, 0, 0, 1)
        _Color2 ("Color 2", Color) = (0, 1, 0, 1)
        _Color3 ("Color 3", Color) = (0, 0, 1, 1)
        _Speed ("Speed", float) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            float _Speed;
            float4 _Color1;
            float4 _Color2;
            float4 _Color3;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float time = _Time.y * _Speed;
                float cycle = fmod(time, 3.0); // ������� ���� �� ���� ������

                if (cycle < 1.0)
                {
                    // ������� �� Color1 � Color2
                    return lerp(_Color1, _Color2, cycle);
                }
                else if (cycle < 2.0)
                {
                    // ������� �� Color2 � Color3
                    return lerp(_Color2, _Color3, cycle - 1.0);
                }
                else
                {
                    // ������� �� Color3 � Color1
                    return lerp(_Color3, _Color1, cycle - 2.0);
                }
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}