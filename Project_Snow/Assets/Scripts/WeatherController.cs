using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.VFX;

[System.Serializable]
public class WeatherData
{
    [Range(0, 10000)]
    public float snowDensity;
    [Range(0,10)]
    public float snowIntensity;
    [Range(0,500)]
    public float fogDistance;
}

public class WeatherController : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    private WeatherData[] weatherData;

    [SerializeField]
    private Volume volume;
    [SerializeField]
    private VisualEffect snowVFX;

    private void UpdateFogDistance(float distance)
    {
        //VolumeProfile profile = volume.sharedProfile;
        //Fog fog;
        //profile.TryGet<Fog>(out fog);

        //fog.meanFreePath.value = distance;
    }

    private void UpdateSnowDensity(float density)
    {
        //snowVFX.SetFloat(1, density);
    }

    private void UpdateWind(float intensity)
    {
        //snowVFX.SetFloat(2, intensity);
    }

    public void AdvanceWeather()
    {
        UpdateFogDistance(weatherData[index].fogDistance);
        UpdateSnowDensity(weatherData[index].snowDensity);
        UpdateWind(weatherData[index].snowIntensity);
    }
}
