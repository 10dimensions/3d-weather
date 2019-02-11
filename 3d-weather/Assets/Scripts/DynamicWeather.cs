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
        //get references to objects

        TimeOfDayRef = GameObject.FindWithTag("timeday");
        WeatherSys = GameObject.FindWithTag("weathersys");

    }

    public void SetDayWeather()
    {   

        // Set Time of Day

        int _hours = System.DateTime.Now.Hour;
        TimeOfDayRef.GetComponent<ToD_Base>().GetSet_fCurrentTimeOfDay = (_hours / 24f);



        //Set Weather Type

        int _weatherID = Singleton._instance.WeatherData.weather[0].id;
        Debug.Log(_weatherID);


        if (_weatherID >= 200 && _weatherID < 250)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.THUNDERSTORM;
            WeatherSys.GetComponent<Weather_Controller>().enabled=true;
            //WeatherSys.GetComponent<Weather_Controller>().EnterNewWeather(4);
        }
        else if (_weatherID >= 300 && _weatherID < 350)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.RAIN;
            WeatherSys.GetComponent<Weather_Controller>().enabled=true;
        }
        else if (_weatherID >= 600 && _weatherID < 650)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.SNOW;
            WeatherSys.GetComponent<Weather_Controller>().enabled=true;
        }
        else if (_weatherID == 800)
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.SUN;
            WeatherSys.GetComponent<Weather_Controller>().enabled=true;
        }
        else
        {
            WeatherSys.GetComponent<Weather_Controller>().en_CurrWeather = Weather_Controller.WeatherType.CLOUDY;
            WeatherSys.GetComponent<Weather_Controller>().enabled=true;
        }

        /*
        SUN,
        CLOUDY,
        RAIN,
        THUNDERSTORM,
        SNOW,*/
    }


}
