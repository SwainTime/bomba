using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesManager : MonoBehaviour
{
    public Slider fieldOfView;
    public Camera camera;
    void Start()
    {
        if(!PlayerPrefs.HasKey("fieldOfView"))
        {
            PlayerPrefs.SetFloat("fieldOfView", 60);
        }

        Load();
    }

    
    public void ChangeView()
    {
        camera.fieldOfView = fieldOfView.value;
        Save();
    }

    public void Load()
    {
        fieldOfView.value = PlayerPrefs.GetFloat("fieldOfView");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("fieldOfView", fieldOfView.value);
    }
}

