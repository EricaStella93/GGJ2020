using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Transform textTransform;

    private void Start()
    {
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        int remainingSeconds = 3;
        float time = 0;
        while (remainingSeconds >= 0)
        {
            text.text = remainingSeconds.ToString();
            time = 0;
            while (time < 1)
            {
                yield return null;
                time += Time.deltaTime;
                textTransform.localScale = new Vector3(1,1,1)*(1-time);
            }

            remainingSeconds--;
        }
    }
}
