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
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void OpenTutorial()
    {
        mainMenu.SetActive(false);
        tutorial.SetActive(true);
        credits.SetActive(false);
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        tutorial.SetActive(false);
        credits.SetActive(true);
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void ClosePanel()
    {
        OpenMainMenu();
    }

    public void Quit()
    {
        //TODO testare se si sente
        SfxManager.Instance.PlayGrunt();
        Application.Quit();
    }

    public void Play()
    {
        SfxManager.Instance.PlayStartButtonClip();
        SceneManager.LoadScene(1);
    }
    
    
}
