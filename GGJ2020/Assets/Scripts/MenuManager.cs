using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorial;
    public GameObject credits;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        tutorial.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenTutorial()
    {
        mainMenu.SetActive(false);
        tutorial.SetActive(true);
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        tutorial.SetActive(false);
        credits.SetActive(true);
    }

    public void ClosePanel()
    {
        OpenMainMenu();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
