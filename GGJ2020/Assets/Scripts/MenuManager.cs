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

    private bool started = false;

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        if (started)
        {
            return;
        }
        mainMenu.SetActive(true);
        tutorial.SetActive(false);
        credits.SetActive(false);
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void OpenTutorial()
    {
        if (started)
        {
            return;
        }
        mainMenu.SetActive(false);
        tutorial.SetActive(true);
        credits.SetActive(false);
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void OpenCredits()
    {
        if (started)
        {
            return;
        }
        mainMenu.SetActive(false);
        tutorial.SetActive(false);
        credits.SetActive(true);
        SfxManager.Instance.PlayMenuButtonClip();
    }

    public void ClosePanel()
    {
        if (started)
        {
            return;
        }
        OpenMainMenu();
    }

    public void Quit()
    {
        started = true;
        SfxManager.Instance.PlayGrunt();
        Invoke("QuitApp", SfxManager.Instance.GruntClipLength);
    }

    public void Play()
    {
        started = true;
        SfxManager.Instance.PlayStartButtonClip();
        Invoke("PlayApp", SfxManager.Instance.PlayButtonClipLength);
    }

    private void PlayApp()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitApp()
    {
        Application.Quit();
    }
}
