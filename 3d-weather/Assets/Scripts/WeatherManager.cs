using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{   
   [SerializeField] private GameObject SnowFX;
   [SerializeField] private GameObject RainFX;
   [SerializeField] private GameObject MistFX;
   [SerializeField] private GameObject CloudFX;

    public enum  WeatherType
    {
        CLEAR,
        FEW_CLOUDS,
        SCATTERED_CLOUDS,
        BROKEN_CLOUDS,
        SHOWER_RAIN,
        RAIN,
        THUNDERSTORM,
        SNOW,
        MIST
    };

    public WeatherType CurrentWeather;
    void Start()
    {
        CurrentWeather = WeatherType.CLEAR;
    }

    public void ChangeWeather(WeatherType _weathertype)
    {
        CurrentWeather = _weathertype;
    }

    private void SpawnWeatherFX()
    {   
        ClearWeather();

        switch(CurrentWeather)
        {
            case WeatherType.CLEAR:
            
            break;

            case WeatherType.FEW_CLOUDS:
            
            break;

            case WeatherType.BROKEN_CLOUDS:
            
            break;

            case WeatherType.SCATTERED_CLOUDS:
            
            break;

            case WeatherType.SHOWER_RAIN:
            
            break;

            case WeatherType.RAIN:
            
            break;

            case WeatherType.THUNDERSTORM:
            
            break;

            case WeatherType.SNOW:
            
            break;

            case WeatherType.MIST:
            
            break;


        }
    }

    private void ClearWeather()
    {

    }
}
