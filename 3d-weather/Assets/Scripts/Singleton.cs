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

    public string CityName;

    [SerializeField] public OpenWeatherData WeatherData;


     void Start()
    {   
        _instance = this;
        DontDestroyOnLoad(gameObject);

        WeatherData = new OpenWeatherData();

        //CallOpenWeather();
    }


    public void CallOpenWeatherGPS()
    {
        string URL = _url + "lat=" + _lat.ToString() + "&lon=" + _lon.ToString() + "&APPID=" + _appid;
        //string URL = _url + "lat=13&lon=80&APPID=" + _appid;

        //StartCoroutine(OpenWeatherAPI(URL));
        StartCoroutine(OpenWeatherAPI.OpenWeatherAPIGPS(URL));
    }

    public void CallOpenWeatherCity()
    {
        string URL = _url + "q="+ CityName +"&APPID=" + _appid;
        
        StartCoroutine(OpenWeatherAPI.OpenWeatherAPICity(URL));
        
    }

    public void APICallSuccess()
    {
        GameObject.FindWithTag("UI").GetComponent<UIManager>().DisplayOnSuccess();
        GameObject.FindWithTag("weatherman").GetComponent<WeatherManager>().SetDayWeather();

        //GameObject.FindWithTag("weatherman").GetComponent<DynamicWeather>().SetDayWeather();
    }
 
}