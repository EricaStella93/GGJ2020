using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int totalTimeInSeconds = 60;
    public TriggerEvent onFinishedTime;
    public int bounceLimit = 5;
    public float maxIncreaseInScale = 0.5f;

    private TextMeshProUGUI timerText;

    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        tr = transform;
        StartCoroutine(TimerLoop());
    }

    IEnumerator TimerLoop()
    {
        int passedTime = 0;
        UpdateTimerText(passedTime);
        while (passedTime < totalTimeInSeconds)
        {
            yield return new WaitForSeconds(1f);
            passedTime++;
            UpdateTimerText(passedTime);
        }
        onFinishedTime.Raise(null);
        SfxManager.Instance.PlayGameFinishedClip();
    }

    private void UpdateTimerText(int passedTime)
    {
        int remainingTime = totalTimeInSeconds - passedTime;
        int minutes = remainingTime / 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, remainingTime % 60);
        if (minutes == 0 && remainingTime <= bounceLimit)
        {
            //TODO scegliere il colore
            StopCoroutine(BounceTimer());
            timerText.color = Color.red;
            StartCoroutine(BounceTimer());
            SfxManager.Instance.PlayLowTimerClip();
        }
    }

    IEnumerator BounceTimer()
    {
        float time = 0;
        while (time < 1)
        {
            yield return null;
            if (time <= 0.5)
            {
                tr.localScale = new Vector3(1,1,1)*(1+Mathf.Lerp(0, maxIncreaseInScale, time/0.5f));
            }
            else
            {
                tr.localScale = new Vector3(1,1,1)*(1+Mathf.Lerp(maxIncreaseInScale, 0, (time-0.5f)/0.5f));
            }

            time += Time.deltaTime;
        }
    }
}
