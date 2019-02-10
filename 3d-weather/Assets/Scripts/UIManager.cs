using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
     [SerializeField] private Button DataButton; 
    [SerializeField] private GameObject DataPanel;

    [SerializeField] private Text LatitudeText;
    [SerializeField] private Text LongitudeText;

    void Start()
    {
         DataButton.onClick.AddListener(()=> DisplayPanel());
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

    public void DisplayOnSuccess()
    {
        LatitudeText.text = "lat: "+ Singleton._instance._lat.ToString();
        LongitudeText.text = "lat: " + Singleton._instance._lon.ToString();
    }
    public void DisplayOnFailure()
    {
        LatitudeText.text = "Unable to determine device location";
        LongitudeText.text = " ";
    }
    public void DisplayOnDisabled()
    {
        LatitudeText.text = "Disabled";
        LongitudeText.text = " ";
    }
    public void DisplayOnTimeOut()
    {
        LatitudeText.text = "Timed-out";
        LongitudeText.text = " ";
    }

}
