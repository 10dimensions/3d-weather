using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Singleton : MonoBehaviour
{
    public static Singleton _instance { get; set;}

    [SerializeField] private string _url;
    [SerializeField] private string _appid;

    public float _lat;
    public float _lon;

    [SerializeField] public OpenWeatherData WeatherData;

    private GameObject TimeOfDayRef;
    private GameObject WeatherSys;

     void Start()
    {   
        _instance = this;
        DontDestroyOnLoad(gameObject);

        TimeOfDayRef = GameObject.FindWithTag("timeday");
        WeatherSys = GameObject.FindWithTag("weathersys");
        WeatherData = new OpenWeatherData();


        CallOpenWeather();
    }


    public void CallOpenWeather()
    {
        //string URL = _url + "lat=" + _lat.ToString() + "&lon=" + _lon.ToString() + "APPID=" + _appid;

        Debug.Log("weather_called");
        string URL = _url + "lat=23&lon=40&APPID=" + _appid;
        StartCoroutine(OpenWeatherAPI(URL));
    }

   public IEnumerator OpenWeatherAPI(string url)
    {

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Cache-Control", "max-age=0, no-cache, no-store");
        www.SetRequestHeader("Pragma", "no-cache");

        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }

        else
        {
            //Debug.Log("Received " + www.downloadHandler.text);
            WeatherData = JsonUtility.FromJson<OpenWeatherData>(www.downloadHandler.text);
            SetDayWeather();
        }
    }

    private void SetDayWeather()
    {
        int _hours = System.DateTime.Now.Hour;
        TimeOfDayRef.GetComponent<ToD_Base>().GetSet_iStartHour = _hours;

        int _weatherID = WeatherData.id;


        if(_weatherID>=200 && _weatherID<250)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.THUNDERSTORM;
        }
        else if (_weatherID >= 300 && _weatherID < 350)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.RAIN;
        }
        else if (_weatherID >= 600 && _weatherID < 650)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.SNOW;
        }
        else if (_weatherID == 800)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.SUN;
        }
        else
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.CLOUDY;
        }

        /*
        SUN,
        CLOUDY,
        RAIN,
        THUNDERSTORM,
        SNOW,*/
    }
 
}