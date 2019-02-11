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


     void Start()
    {   
        _instance = this;
        DontDestroyOnLoad(gameObject);

        WeatherData = new OpenWeatherData();

        CallOpenWeather();
    }


    public void CallOpenWeather()
    {
        string URL = _url + "lat=" + _lat.ToString() + "&lon=" + _lon.ToString() + "APPID=" + _appid;
        //string URL = _url + "lat=13&lon=80&APPID=" + _appid;

        //StartCoroutine(OpenWeatherAPI(URL));
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
            Debug.Log("Received " + www.downloadHandler.text);
            WeatherData = JsonUtility.FromJson<OpenWeatherData>(www.downloadHandler.text);

            GameObject.FindWithTag("UI").GetComponent<UIManager>().DisplayOnSuccess();
            GameObject.FindWithTag("weatherman").GetComponent<DynamicWeather>().SetDayWeather();
        }
    }
 
}