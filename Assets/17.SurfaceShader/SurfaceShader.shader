Shader "Custom/MyPoorShader"
{
    Properties
    {
        _MainTex("Texture",2D)="white"{}
        _ColorMultiple("Color Multiplier",Range(0,1))=1
    }
    SubShader
    {
        Tags{"RenderType"="Opaque"}
        CGPROGRAM
        #pragma surface surf Lambert 
        sampler2D _MainTex;
        float _ColorMultiple;
        struct Input
        {
            float2/*유니티로 치면 Vector2*/ uv_MainTex;
        };
        void surf(Input IN, inout SurfaceOutput output)
        {
            output.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _ColorMultiple;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
