using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;


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

public class WeatherManager : MonoBehaviour
{   
    public WeatherType CurrentWeather;

    [Header("FX References")]
   public GameObject SnowFX ;
   public GameObject RainFX ;
   public GameObject MistFX;

   [Header("Skybox Colors")]
   [SerializeField] private Color SnowColor;
   [SerializeField]private Color CloudColor;
   [SerializeField]private Color RainColor;
    [SerializeField]private Color ClearColor;

    [Header("TimeDay")]
    public float _time;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light Sun;
    public int days;
    public float intensity;
    public int speed;



    //private Dictionary<string, WeatherType> WeatherMapping;

    void Start()
    {   
        //WeatherMapping = new Dictionary<string, WeatherType>();
        //ComposeDictionary();

        CurrentWeather = WeatherType.CLEAR;

        // Set Time of Day
        _time = (float) System.DateTime.Now.TimeOfDay.TotalSeconds;
        Debug.Log(_time);
        //int _hours = System.DateTime.Now.Hour;
    }


    void Update()
    {
        SetSunPos();
    }


       public void SetDayWeather()
    {   

        //TimeOfDayRef.GetComponent<ToD_Base>().GetSet_fCurrentTimeOfDay = (_hours / 24f);


        //Set Weather Type

        int _weatherID = Singleton._instance.WeatherData.weather[0].id;
        Debug.Log(_weatherID);


        if (_weatherID >= 200 && _weatherID < 250)
        {
            CurrentWeather = WeatherType.THUNDERSTORM;
        }
        else if (_weatherID >= 300 && _weatherID < 350)
        {
            CurrentWeather =WeatherType.RAIN;
        }
        else if (_weatherID >= 500 && _weatherID < 550)
        {
            CurrentWeather =WeatherType.RAIN;
        }
        else if (_weatherID >= 600 && _weatherID < 650)
        {
            CurrentWeather =WeatherType.SNOW;
        }
        else if (_weatherID >= 700 && _weatherID < 750)
        {
            CurrentWeather =WeatherType.MIST;
        }
        else if (_weatherID == 800)
        {
            CurrentWeather = WeatherType.CLEAR;
        }
        else
        {
           CurrentWeather =WeatherType.FEW_CLOUDS;
        }

        
        Debug.Log(CurrentWeather);
        SpawnWeatherFX();

    }

    public void ChangeWeather(WeatherType _weathertype)
    {
        CurrentWeather = _weathertype;
    }

    private void SpawnWeatherFX()
    {   
        //ClearWeather();
        RemoveAllFX();


        switch(CurrentWeather)
        {
            case WeatherType.CLEAR:
            RenderSettings.skybox.SetColor("_Tint", ClearColor);
            
            break;

            case WeatherType.FEW_CLOUDS:
            RenderSettings.skybox.SetColor("_Tint", CloudColor);
            
            break;

            case WeatherType.BROKEN_CLOUDS:
            RenderSettings.skybox.SetColor("_Tint", CloudColor);
            
            break;

            case WeatherType.SCATTERED_CLOUDS:
            RenderSettings.skybox.SetColor("_Tint", CloudColor);
            
            break;

            case WeatherType.SHOWER_RAIN:
            RenderSettings.skybox.SetColor("_Tint", RainColor);

            GameObject _srainfx = Instantiate(RainFX) as GameObject;
            _srainfx.transform.parent=transform;
            _srainfx.transform.localPosition = new Vector3(0f,0f,0f);
            _srainfx.SetActive(true);
            
            break;

            case WeatherType.RAIN:
            RenderSettings.skybox.SetColor("_Tint", RainColor);

            GameObject _rainfx = Instantiate(RainFX) as GameObject;
            _rainfx.transform.parent = transform;
            _rainfx.transform.localPosition = new Vector3(0f,0f,0f);
            _rainfx.SetActive(true);

            break;

            case WeatherType.THUNDERSTORM:
            RenderSettings.skybox.SetColor("_Tint", RainColor);

            GameObject _thrainfx = Instantiate(RainFX) as GameObject;
            _thrainfx.transform.parent = transform;  
            _thrainfx.transform.localPosition = new Vector3(0f,0f,0f);
            _thrainfx.SetActive(true);
            
            break;

            case WeatherType.SNOW:
            RenderSettings.skybox.SetColor("_Tint", SnowColor);

            GameObject _snowfx = Instantiate(SnowFX) as GameObject;
            _snowfx.transform.parent =transform;
            _snowfx.transform.localPosition = new Vector3(0f,0f,0f);
            _snowfx.SetActive(true);
            
            break;

            case WeatherType.MIST:
            RenderSettings.skybox.SetColor("_Tint", CloudColor);

            GameObject _mistfx = Instantiate(MistFX) as GameObject;
            _mistfx.transform.parent = transform;
            //_mistfx.transform.localPosition = new Vector3(0f,0f,0f);
            _mistfx.SetActive(true);
            
            break;


        }
    }

    private void ClearWeather()
    {   
        CurrentWeather = WeatherType.CLEAR;
        RenderSettings.skybox.SetColor("_Tint", Color.blue);
    }

    private void RemoveAllFX()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }



    private void SetSunPos()
    {
        _time += Time.deltaTime * speed;

        if(_time> 86400)
        {
            days += 1;
            _time=0;
        }

        currentTime = TimeSpan.FromSeconds(_time);

        SunTransform.rotation = Quaternion.Euler(new Vector3((_time-21600)/86400, 0, 0));

        if(_time < 43200)
        {
            intensity = 1- (43200-_time)/43200;
        }
        else
        {
            intensity = 1- ((43200-_time)/43200 * -1);
        }
    
        Sun.intensity = intensity;
    }
}
