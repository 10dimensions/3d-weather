using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OpenWeatherData
{   
    [System.Serializable]
    public class Coord
    {
        public double lon;
        public double lat;
    }

    [System.Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    [System.Serializable]
    public class Main
    {
        public double temp;
        public int pressure;
        public int humidity;
        public double temp_min;
        public double temp_max;
    }

    [System.Serializable]
    public class Wind
    {
        public double speed;
        public int deg;
    }

    [System.Serializable]
    public class Clouds
    {
        public int all;
    }

    [System.Serializable]
    public class Rain
    {
        public int __invalid_name__3h;
    }

    [System.Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public double message;
        public string country;
        public int sunrise;
        public int sunset;
    }

    public Coord coord;
    public List<Weather> weather;
    public string @base;
    public Main main;
    public Wind wind;
    public Clouds clouds;
    public Rain rain;
    public int dt;
    public Sys sys;
    public int id;
    public string name;
    public int cod;

}