using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationProvider : MonoBehaviour
{
    private GameObject UIRef;

    void Start()
    {
        UIRef = GameObject.FindWithTag("UI");
        StartCoroutine(GetLocation());
    }

    public IEnumerator GetLocation()
    {
        if (!Input.location.isEnabledByUser)
            {   
                Debug.Log("disabled");
                UIRef.GetComponent<UIManager>().DisplayOnDisabled();
                yield break;
            }

       Input.location.Start();

       int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
            Debug.Log(maxWait);
        }

        if (maxWait < 1)
        {
            print("Timed out");
            UIRef.GetComponent<UIManager>().DisplayOnTimeOut();
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            UIRef.GetComponent<UIManager>().DisplayOnFailure();
            yield break;
        }

        else
        {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            Singleton._instance._lat = (Input.location.lastData.latitude); 
            Singleton._instance._lon = (Input.location.lastData.longitude);

            //Singleton._instance.CallOpenWeather();

            UIRef.GetComponent<UIManager>().DisplayOnSuccess();
        }

        Input.location.Stop();
    }
}
