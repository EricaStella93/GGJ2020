using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SfxManager : Singleton<SfxManager>
{
    //Suoni menu principale
    [SerializeField] private AudioClip menuButtonClip;
    [SerializeField] private AudioClip playButtonClip;

    //Suoni video
    
    //Suoni scena principale
    [SerializeField] private AudioClip[] letterAcceptedClips;
    [SerializeField] private AudioClip newWordClip;
    [SerializeField] private AudioClip halfWordClip;
    [SerializeField] private AudioClip fullWordClip;
    [SerializeField] private AudioClip innkeeperGrunt;
    [SerializeField] private AudioClip gameFinishedClip;
    [SerializeField] private AudioClip lowTimerClip;

    public float minWaitForGrunt = 4f;
    public float maxWaitForGrunt = 10f;
    
    private AudioSource source;

    private bool stopped = false;

    public float PlayButtonClipLength
    {
        get { return playButtonClip.length; }
    }
    
    public float GruntClipLength
    {
        get { return innkeeperGrunt.length; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        AudioSource[] sources = GetComponents<AudioSource>();
        source = sources[0];
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            StartGrunts();
        }
    }

    public void PlayMenuButtonClip()
    {
        source.PlayOneShot(menuButtonClip);
    }
    
    public void PlayStartButtonClip()
    {
        source.PlayOneShot(playButtonClip);
    }
    
    public void PlayLetterAcceptedClip()
    {
        int clipToPlay = Random.Range(0, letterAcceptedClips.Length);
        source.PlayOneShot(letterAcceptedClips[clipToPlay]);
    }

    public void PlayNewWordClip()
    {
        source.PlayOneShot(newWordClip);
    }
    
    public void PlayHalfWordClip()
    {
        source.PlayOneShot(halfWordClip);
    }
    
    public void PlayFullWordClip()
    {
        source.PlayOneShot(fullWordClip);
    }
    
    public void PlayGameFinishedClip()
    {
        source.PlayOneShot(gameFinishedClip);
        StopGrunts();
    }

    public void PlayLowTimerClip()
    {
        source.PlayOneShot(lowTimerClip);
    }

    public void PlayGrunt()
    {
        source.PlayOneShot(innkeeperGrunt);
    }

    IEnumerator PlayInnkeeperGrunt()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(10f);
            if (!stopped)
            {
                source.PlayOneShot(innkeeperGrunt);
            }
        }
    }

    public void StartGrunts()
    {
        stopped = false;
        StartCoroutine(PlayInnkeeperGrunt());
    }

    public void StopGrunts()
    {
        stopped = true;
        StopCoroutine(PlayInnkeeperGrunt());
    }
}
