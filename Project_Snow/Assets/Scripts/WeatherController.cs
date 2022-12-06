using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.VFX;

[System.Serializable]
public class WeatherData
{
    public float snowDensity;
    public float snowIntensity;
    public float fogDistance;
}

public class WeatherController : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private WeatherData[] weatherData;

    public float snowDensity
    {
        get { return snowDensity; }
        set { snowDensity = Mathf.Clamp(value, 0, 10000); UpdateSnowDensity(); }
    }
    public float snowIntensity
    {
        get { return snowIntensity; }
        set { snowIntensity = Mathf.Clamp(value, 0, 10); UpdateWind(); }
    }
    public float fogDistance
    {
        get { return fogDistance; }
        set { fogDistance = Mathf.Clamp(value, 0, 500); UpdateFogDistance(); }
    }

    [SerializeField]
    private Volume volume;
    [SerializeField]
    private VisualEffect snowVFX;

    private void UpdateFogDistance()
    {
        VolumeProfile profile = volume.sharedProfile;
        Fog fog;
        profile.TryGet<Fog>(out fog);

        fog.meanFreePath.value = fogDistance;
    }

    private void UpdateSnowDensity()
    {
        snowVFX.SetFloat(1, snowDensity);
    }

    private void UpdateWind()
    {
        snowVFX.SetFloat(2, snowIntensity);
    }

    public void AdvanceWeather()
    {
        fogDistance = weatherData[index].fogDistance;
        snowIntensity = weatherData[index].snowIntensity;
        snowDensity = weatherData[index].snowDensity;
    }
}
