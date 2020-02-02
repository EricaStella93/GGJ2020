using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenuManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject countdown;
    public GameObject points;
    public TextMeshProUGUI redPoints;
    public TextMeshProUGUI bluePoints;

    private void Start()
    {
        redPoints.text = PointManager.Instance.redPoints.ToString();
        bluePoints.text = PointManager.Instance.bluePoints.ToString();
    }

    public void QuickReplayButton()
    {
        points.SetActive(false);
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
