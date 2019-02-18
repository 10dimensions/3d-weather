using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class OpenWeatherAPI
{
    public static IEnumerator OpenWeatherAPIGPS(string url)
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
            Singleton._instance.WeatherData = JsonUtility.FromJson<OpenWeatherData>(www.downloadHandler.text);
            Singleton._instance.APICallSuccess();
        }
    }

    public static IEnumerator OpenWeatherAPICity(string url)
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
            Singleton._instance.WeatherData = JsonUtility.FromJson<OpenWeatherData>(www.downloadHandler.text);
            Singleton._instance.APICallSuccess();
        }
    }
}
