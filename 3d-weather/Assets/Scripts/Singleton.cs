using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Singleton : MonoBehaviour
{   
    [SerializeField] private string url;
    [SerializeField] private float lat;
    [SerializeField] private float lon;

    public OpenWeather WeatherData;

     void Start()
    {
        WeatherData = new OpenWeather();
        StartCoroutine(OpenWeatherAPI(url));
    }
 void Update()
    {
        
    }

    public void CallOpenWeather()
    {

    }

   IEnumerator OpenWeatherAPI(string url)
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
        WeatherData = JsonUtility.FromJson<OpenWeather>(www.downloadHandler.text);
    }
}
 
}
