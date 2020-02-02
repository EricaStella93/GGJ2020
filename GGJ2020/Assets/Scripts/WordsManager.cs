using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public RepairableObject[] objectPool;

    public WordCompleter redTeam;
    public WordCompleter blueTeam;

    private int redCurrentWord = -1;
    private int blueCurrentWord = -1;

    private bool timerOver;

    private static WordsManager instance = null;


    public static WordsManager Instance
    {
        get
        { 
            return instance; 
        }
    }
     
     private void Awake()
     {
         // if the singleton hasn't been initialized yet
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad( this.gameObject );
     }

    // Start is called before the first frame update
    void Start()
    {
        redTeam.setObjectToRepair(extractNewObject(true));
        blueTeam.setObjectToRepair(extractNewObject(false));
    }

    public RepairableObject extractNewObject(bool red)
    {
        int extract = Random.Range(0, objectPool.Length);
        while(extract == redCurrentWord || extract == blueCurrentWord)
        {
            extract = Random.Range(0, objectPool.Length);
        }
        if(red)
        {
            redCurrentWord = extract;
        }
        else
        {
            blueCurrentWord = extract;
        }
        return objectPool[extract]; //maybe try to make impossible to get the same one two times in a row?
        //and maybe that it can't be the enemy team's word

    }

    public void setTimerOver(bool newTimer)
    {
        timerOver = newTimer;
    }

    public bool isTimerOver()
    {
        return timerOver;
    }
}
