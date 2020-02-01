using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int redPoints = 0;
    public int bluePoints = 0;
    private static PointManager instance = null;

    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI blueScoreText;

    public static PointManager Instance
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void score(bool red)
    {
        if(red)
        {
            redPoints++;
            redScoreText.text = ""+redPoints;
        }
        else
        {
            bluePoints++;
            blueScoreText.text = ""+bluePoints;
        }
    }

    public void reset()
    {
        redPoints = 0;
        bluePoints = 0;
    }

    public bool redWinning()
    {
        return redPoints > bluePoints;
    }

    public bool isDraw()
    {
        return redPoints == bluePoints;
    }
}
