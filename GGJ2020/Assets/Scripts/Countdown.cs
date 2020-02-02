using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public GameObject[] objToDeactivateAtStart;
    
    public TextMeshProUGUI text;
    public Transform textTransform;

    public UnityEvent onFinishCountdown;

    public AudioClip clip;
    public AudioSource source;
    

    private void Start()
    {
        if (objToDeactivateAtStart != null)
        {
            for (int i = 0; i < objToDeactivateAtStart.Length; i++)
            {
                objToDeactivateAtStart[i].SetActive(false);
            }
        }
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        int remainingSeconds = 3;
        float time = 0;
        while (remainingSeconds > 0)
        {
            text.text = remainingSeconds.ToString();
            source.PlayOneShot(clip);
            time = 0;
            while (time < 1)
            {
                yield return null;
                time += Time.deltaTime;
                textTransform.localScale = new Vector3(1,1,1)*(1-time);
            }

            remainingSeconds--;
        }
        
        onFinishCountdown.Invoke();
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
