using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePostProcess : MonoBehaviour
{
    PostProcessVolume volume;
    AmbientOcclusion ambientOcclusionLayer;
    Bloom bloomLayer;
    ColorGrading colorGradingLayer;
    DepthOfField depthOfFieldLayer;
    Vignette vignetteLayer;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();

        volume.profile.TryGetSettings(out ambientOcclusionLayer);
        volume.profile.TryGetSettings(out bloomLayer);
        volume.profile.TryGetSettings(out colorGradingLayer);
        volume.profile.TryGetSettings(out depthOfFieldLayer);
        volume.profile.TryGetSettings(out vignetteLayer);
    }

    public void AmbientOcclusionActive()
    {
        ambientOcclusionLayer.quality.value = AmbientOcclusionQuality.Ultra;
        bloomLayer.active = true;
    }
}
