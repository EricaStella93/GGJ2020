using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageFading : MonoBehaviour
{
    public bool first;
    public bool last;
    public ImageFading next;

    private Image image;
    public float startFadingTime;
    public bool activeFade = false;

    [Range(0.0f,1.0f)]
    public float fadingSpeed;

    private float startFadeValue = 1;

    public AudioSource source;
    public AudioClip clip;

    private bool playedClip = false;

    public float clipValue;

    public GameObject countdownObj;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if(first)
        {
            startFading();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activeFade)
        {
            if(!last)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, startFadeValue);
                next.GetImage().color = new Color(image.color.r, image.color.g, image.color.b, 1-startFadeValue);
            }
            startFadeValue = Mathf.Lerp(startFadeValue, 0, fadingSpeed);
            if(startFadeValue < clipValue && clip && !playedClip && !last)
            {
                source.PlayOneShot(clip);
                playedClip = true;
            }
            if(startFadeValue < 0.01f)
            {
                if(!last)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    next.GetImage().color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
                activeFade = false;
                if(!last)
                {
                    next.startFading();
                }
                else
                {
                    //TODO far partire prima
                    //TODO suoni countdown
                    source.PlayOneShot(clip);
                    playedClip = true;
                    countdownObj.SetActive(true);
                }
            }
        }
    }

    public void startFading()
    {
        Invoke("fadingActivate", startFadingTime);   
        
    }

    public Image GetImage()
    {
        return image;
    }
    public void fadingActivate()
    {
        activeFade = true;
    }
}
