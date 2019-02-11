using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class UIManager : MonoBehaviour
{   
    [SerializeField] private Button LocationButton;
    [SerializeField] private Button DataBackButton;
     [SerializeField] private Button DataButton; 
     [SerializeField] private Button ExitButton; 
     [SerializeField] private Button NoExitButton;
      

     [SerializeField] private GameObject LocatePanel;
     [SerializeField] private GameObject DataPanel;
     [SerializeField] private GameObject ExitPanel;

    [SerializeField] private Text LatitudeText;
    [SerializeField] private Text LongitudeText;
    [SerializeField] private Text LocationName;
    [SerializeField] private Text CurrTemp;
    [SerializeField] private Text MinMaxTemp;
    [SerializeField] private Text Humidity;
    [SerializeField] private Text WindSpeed;
    [SerializeField] private Text WeatherType;
    [SerializeField] private RawImage WeatherImage;


    [SerializeField] private Text ResponseText;

    void Start()
    {   
        LocationButton.onClick.AddListener(()=>GetLocationFromGPS());
        DataButton.onClick.AddListener(()=> DisplayPanel());
        DataBackButton.onClick.AddListener(()=>DisplayPanel());

        ExitButton.onClick.AddListener(()=> ExitApplication());
        NoExitButton.onClick.AddListener(()=> DoNotExit());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(!ExitPanel.activeSelf)
                ExitPanel.SetActive(true);
        }
    }

    public void DisplayOnSuccess()
    {   

        StartCoroutine(GetTexture(Singleton._instance.WeatherData.weather[0].icon));

        LatitudeText.text = "lat: "+ Singleton._instance._lat.ToString();
        LongitudeText.text = "lat: " + Singleton._instance._lon.ToString();

        LocationName.text = Singleton._instance.WeatherData.name;

        double _currtemp = Math.Round((Singleton._instance.WeatherData.main.temp-273.15),2);
        double _mintemp = Math.Round((Singleton._instance.WeatherData.main.temp_min-273.15),2);
        double _maxtemp = Math.Round((Singleton._instance.WeatherData.main.temp_max-273.15),2);

        CurrTemp.text = _currtemp.ToString() + " C";
        MinMaxTemp.text = "↓" + _mintemp.ToString() + " C    ↑" + _maxtemp.ToString()+" C";

        Humidity.text = "Humidty: "+Singleton._instance.WeatherData.main.humidity.ToString();
        WindSpeed.text = "Wind: "+Singleton._instance.WeatherData.wind.speed.ToString();
        WeatherType.text = Singleton._instance.WeatherData.weather[0].description.ToString();




    }

     IEnumerator GetTexture(string img_type) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://openweathermap.org/img/w/"+ img_type + ".png");
        yield return www.SendWebRequest();

        WeatherImage.texture = DownloadHandlerTexture.GetContent(www);
    }


    public void DisplayOnFailure()
    {
        ResponseText.text = "Unable to determine device location";
    }
    public void DisplayOnDisabled()
    {
        ResponseText.text = "Disabled";
    }
    public void DisplayOnTimeOut()
    {
        ResponseText.text = "Timed-out";
    }


/////////////   UI    ScreenFlow  ////////////////////// 

    private void GetLocationFromGPS()
    {
        StartCoroutine(GameObject.FindWithTag("locator").GetComponent<LocationProvider>().GetLocation());
    }

    private void FadeOutLocatePanel()
    {
        LocatePanel.SetActive(false);
    }
     private void DisplayPanel()
    {
        if(DataPanel.activeSelf)
        {
            DataPanel.SetActive(false);
        }
        else if(!DataPanel.activeSelf)
        {
            DataPanel.SetActive(true);
        }
    }

    private void DoNotExit()
    {
        ExitPanel.SetActive(false);
    }

    private void ExitApplication()
    {
        Application.Quit();
    }



}
