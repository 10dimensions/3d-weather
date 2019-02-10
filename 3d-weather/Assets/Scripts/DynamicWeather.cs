using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DynamicWeather : MonoBehaviour
{   
    private GameObject TimeOfDayRef;
    private GameObject WeatherSys;

    private void Start()
    {
        TimeOfDayRef = GameObject.FindWithTag("timeday");
        WeatherSys = GameObject.FindWithTag("weathersys");

    }

    public void SetDayWeather()
    {   

        // Set Time of Day

        int _hours = System.DateTime.Now.Hour;
        TimeOfDayRef.GetComponent<ToD_Base>().GetSet_fCurrentTimeOfDay = (_hours / 24f);



        //Set Weather Type

        int _weatherID = Singleton._instance.WeatherData.id;


        if (_weatherID >= 200 && _weatherID < 250)
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
