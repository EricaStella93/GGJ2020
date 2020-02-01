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
        sourceOne = sources[0];
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
        sourceOne.PlayOneShot(menuButtonClip);
    }
    
    public void PlayStartButtonClip()
    {
        sourceOne.PlayOneShot(playButtonClip);
    }
    
    public void PlayLetterAcceptedClip()
    {
        int clipToPlay = Random.Range(0, letterAcceptedClips.Length);
        sourceOne.PlayOneShot(letterAcceptedClips[clipToPlay]);
    }

    public void PlayNewWordClip()
    {
        sourceOne.PlayOneShot(newWordClip);
    }
    
    public void PlayHalfWordClip()
    {
        sourceOne.PlayOneShot(halfWordClip);
    }
    
    public void PlayFullWordClip()
    {
        sourceOne.PlayOneShot(fullWordClip);
    }
    
    public void PlayGameFinishedClip()
    {
        sourceOne.PlayOneShot(gameFinishedClip);
        StopGrunts();
    }

    public void PlayGrunt()
    {
        sourceOne.PlayOneShot(innkeeperGrunt);
    }

    IEnumerator PlayInnkeeperGrunt()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(10f);
            if (!stopped)
            {
                sourceOne.PlayOneShot(innkeeperGrunt);
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
