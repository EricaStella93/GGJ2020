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

    public float minWaitForGrunt = 4f;
    public float maxWaitForGrunt = 10f;
    
    private AudioSource sourceOne;
    private AudioSource sourceTwo;

    private bool stopped = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        AudioSource[] sources = GetComponents<AudioSource>();
        sourceOne = sources[0];
        sourceTwo = sources[1];
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
        sourceOne.clip = menuButtonClip;
        sourceOne.Play();
    }
    
    public void PlayStartButtonClip()
    {
        sourceOne.clip = playButtonClip;
        sourceOne.Play();
    }
    
    public void PlayLetterAcceptedClip()
    {
        int clipToPlay = Random.Range(0, letterAcceptedClips.Length);
        sourceOne.clip = letterAcceptedClips[clipToPlay];
        sourceOne.Play();
    }

    public void PlayNewWordClip()
    {
        sourceOne.clip = newWordClip;
        sourceOne.Play();
    }
    
    public void PlayHalfWordClip()
    {
        sourceOne.clip = halfWordClip;
        sourceOne.Play();
    }
    
    public void PlayFullWordClip()
    {
        sourceOne.clip = fullWordClip;
        sourceOne.Play();
    }
    
    public void PlayGameFinishedClip()
    {
        sourceOne.clip = gameFinishedClip;
        sourceOne.Play();
        StopGrunts();
    }

    public void PlayGrunt()
    {
        sourceOne.clip = innkeeperGrunt;
        sourceOne.Play();
    }

    IEnumerator PlayInnkeeperGrunt()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(10f);
            if (!stopped)
            {
                sourceTwo.clip = innkeeperGrunt;
                sourceTwo.Play();
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
