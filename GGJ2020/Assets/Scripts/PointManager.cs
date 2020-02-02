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

    private SizeTween redPointTween;
    private SizeTween bluePointTween;

    public static PointManager Instance
    {
        get
        { 
            return instance; 
        }
    }
    void Start()
    {
        redPointTween = redScoreText.gameObject.GetComponent<SizeTween>();
        
        bluePointTween = blueScoreText.gameObject.GetComponent<SizeTween>();
    }
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void score(bool red)
    {
        if(red)
        {
            redPoints++;
            redScoreText.text = ""+redPoints;
            redPointTween.restart();
        }
        else
        {
            bluePoints++;
            blueScoreText.text = ""+bluePoints;
            bluePointTween.restart();
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
