Shader "Custom/HealthBarShaderMesh_01"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _FillTex("Fill Texture", 2D) = "white" {}
        _FillAmount("Fill Amount", Range(0, 1)) = 0.01
        _MeshHeight("Mesh Height", Float) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }

            CGPROGRAM
            #pragma surface surf Standard

            sampler2D _MainTex;
            sampler2D _FillTex;
            float _FillAmount;
            float _MeshHeight;

            struct Input
            {
                float2 uv_MainTex;
                float2 uv_FillTex;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                float fillAmount = -IN.worldPos.y >= (_FillAmount * _MeshHeight) ? 1.0f : 0.0f;
                fillAmount = 1.0f - fillAmount;

                float4 mainColor = tex2D(_MainTex, IN.uv_MainTex);
                float4 fillColor = tex2D(_FillTex, float2(IN.uv_MainTex.x, fillAmount + 190));

                float4 finalColor = lerp(mainColor, fillColor, fillAmount);

                o.Albedo = finalColor.rgb;
                o.Alpha = finalColor.a;
            }
            ENDCG
        }

            FallBack "Diffuse"
}
