Shader "Custom/MyPoorShader"
{
    Properties
    {
        _MainTex("Texture",2D)="white"{}
        OverlapTex("Overlap Texture",2D)="gray"{}
        _ColorMultiple("Color Multiplier",Range(0,1))=1
        _ClippingMultiple("Clipping Multiplier",integer)=1
        _ClippingInclin("Clipping Inclination",Float)=1
    }
    SubShader
    {
        Tags{"RenderType"="Opaque"}
        CGPROGRAM
        #pragma surface surf Lambert 
        sampler2D _MainTex;
        sampler2D OverlapTex;
        float _ColorMultiple;
        int _ClippingMultiple;
        float _ClippingInclin;

        struct Input
        {
            float2/*유니티로 치면 Vector2*/ uv_MainTex;
            //float2 uvOverlapTex;
            float4 screenPos;
            float3 worldPos;
        };

        void surf(Input IN, inout SurfaceOutput output)
        {
        // 월드 좌표 기준으로 자른다
        //clip(frac(IN.worldPos.y*_ClippingMultiple)-0.5);
        //clip(frac(IN.worldPos.y*_ClippingMultiple)+(IN.worldPos.x*_ClippingInclin)-0.5);
        // 위와 아래는 다르다. 괄호 주의
        clip(frac((IN.worldPos.y*_ClippingMultiple)+(IN.worldPos.x*_ClippingInclin))-0.5);
            output.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _ColorMultiple;
            //output.Albedo*=tex2D(OverlapTex,IN.uvOverlapTex);
            float2 screenUV=(IN.screenPos.xy/IN.screenPos.w)*float2(10,5);

            float2 timeScale=float2(_SinTime.w,0);

            //output.Albedo*=tex2D(OverlapTex,screenUV+_CosTime.w).rgb*2;
            output.Albedo*=tex2D(OverlapTex,screenUV+_CosTime.w+timeScale).rgb*2;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
