using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class WeatherController : MonoBehaviour
{
    public float snowDensity;
    public float snowIntensity;

    public float fogDistance;

    [SerializeField]
    private Volume volume;
    [SerializeField]
    private VolumeComponent volumeComponent;



    private void UpdateFogDistance()
    {
        VolumeProfile profile = volume.sharedProfile;
        if (!profile.TryGet<Fog>(out var fog))
        {
            fog = profile.Add<Fog>(false);
        }
        fog.Override(volumeComponent, fogDistance);
    }
}
