﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Precipitate : MonoBehaviour
{
    private bool active = false;
    public float speed = 3.0f;
    public float acc = 2.0f;

    public float damp = 0.3f;

    public float targetY = 255; //to change later?

    private Image image;

    public TextMeshProUGUI endText;

    public GameObject canvasReplay;

    public bool red;

    RectTransform rectTransform;

    public TriggerEvent onSpareggio;

    private Vector3 startingPosition;
    private float initialSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        startingPosition = rectTransform.localPosition;
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            rectTransform.localPosition += Vector3.down * speed * Time.deltaTime;
            speed += acc;
            if(rectTransform.localPosition.y <= targetY && speed > 0)
            {
                speed = -1*damp*speed;
                if(Mathf.Abs(speed) < 5f)
                {
                    speed = 0;
                    if (PointManager.Instance.isDraw())
                    {
                        if (onSpareggio)
                        {
                            onSpareggio.Raise(null);
                        }
                    }
                    else
                    {
                        canvasReplay.SetActive(true);
                    }

                }
            }

        }
    }

    public void Reset()
    {
        active = false;
        rectTransform.localPosition = startingPosition;
        speed = initialSpeed;
    }

    public void Activate()
    {
        Debug.Log("Activate");
        active = true;
        if (PointManager.Instance.isDraw())
        {
           endText.text = "Last Blood!!!";
           return;
        }
        if(PointManager.Instance.redWinning() == red)
        {
            endText.text = "Ya winn!";
        }
        else
        {
            endText.text = "Ya lose!";
        }

    }
}
