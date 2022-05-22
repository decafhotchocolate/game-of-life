using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public string playSceneName;

    private GameObject mainMenu;
    private GameObject settingsMenu;
    private TMP_InputField x;
    private TMP_InputField y;

    // Update is called once per frame
    void Awake()
    {
        mainMenu = GameObject.Find("Main Menu");
        x = GameObject.Find("xInput").GetComponent<TMP_InputField>();
        y = GameObject.Find("yInput").GetComponent<TMP_InputField>();
        settingsMenu = GameObject.Find("Settings Menu");
        settingsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        if (x.text != "")
            StateNameController.gridWidth = Convert.ToInt32(x.text);
        else
            StateNameController.gridWidth = 20;

        if (y.text != "")
            StateNameController.gridHeight = Convert.ToInt32(y.text);
        else
            StateNameController.gridHeight = 20;
            

        SceneManager.LoadSceneAsync(playSceneName, LoadSceneMode.Single);
    }
    
    public void EnterSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
