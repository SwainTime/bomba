using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            SettingsGone();
        }
    }

    //Time.timeScale 1 - normal 2 - 2 ori viteza 3-.... 0.5 - 2 ori mai incet
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SettingsLoad()
    {
        settingsMenu.SetActive(true);
    }

    public void SettingsGone()
    {
        settingsMenu.SetActive(false);
    }
}
