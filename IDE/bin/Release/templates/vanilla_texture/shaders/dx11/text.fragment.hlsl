#include "ShaderConstants.fxh"

struct PS_Input
{
    float4 position : SV_Position;
    float4 color : COLOR;
    float2 uv : TEXCOORD_0_FB_MSAA;
};

struct PS_Output
{
    float4 color : SV_Target;
};

void main(in PS_Input PSInput, out PS_Output PSOutput)
{
    float4 diffuse = TEXTURE_0.Sample(TextureSampler0, PSInput.uv);

#ifdef SMOOTH
    const float center = 0.4f;
    const float radius = 0.1f;

    diffuse = smoothstep(center - radius, center + radius, diffuse);
#endif

#ifdef ALPHA_TEST
    if (diffuse.a < 0.5)
    {
        discard;
    }
#endif

    PSOutput.color = diffuse * PSInput.color * DARKEN;
}