using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenuManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject countdown;

    public void QuickReplayButton()
    {
        buttons.SetActive(false);
        countdown.SetActive(true);
    }
    
    public void QuickReplay()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
