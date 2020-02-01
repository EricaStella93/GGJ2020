using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int totalTimeInSeconds = 60;
    public TriggerEvent onFinishedTime;

    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
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
    }

    private void UpdateTimerText(int passedTime)
    {
        int remainingTime = totalTimeInSeconds - passedTime;
        int minutes = remainingTime / 60;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, remainingTime % 60);

    }
}
