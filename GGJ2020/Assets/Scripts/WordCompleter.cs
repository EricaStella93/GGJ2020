using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCompleter : MonoBehaviour
{
    public Image objectSprite;
    
    private RepairableObject objectToRepair;

    private int count; //number of letters in the object

    public bool red;
    private int currentLetter = 0; //how many letters already typed

    public Text text;

    public float pause = 0.2f;

    private SizeTween textTween;

    void Start()
    {
      textTween = text.gameObject.GetComponent<SizeTween>();  
    }
    
    void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && !WordsManager.Instance.isTimerOver())
            {
                if(e.character == objectToRepair.name[currentLetter])
                {
                    currentLetter++;
                    text.text = "<color=green>";
                    for(int i = 0; i < count; i++)
                    {
                        text.text += objectToRepair.name[i];
                        if(i == currentLetter-1)
                        {
                            text.text += "</color>";
                        }
                    }
                    if(currentLetter >= count)
                    {
                       FinishedWord();
                       Invoke("changeWord",pause);     
                    }
                    else
                    {
                        UpdatedWord();
                    }
                }
            }
        }

    public void changeWord()
    {
        PointManager.Instance.score(red);
        if(!WordsManager.Instance.isTimerOver())
            setObjectToRepair(WordsManager.Instance.extractNewObject(red));
    }

    public void setObjectToRepair(RepairableObject newObject)
    {
        objectToRepair = newObject;
        objectSprite.sprite = objectToRepair.images[0];
        text.text = objectToRepair.name;
        currentLetter = 0;
        count = newObject.name.Length;
        textTween.restart();
    }

    private void FinishedWord()
    {
        objectSprite.sprite = objectToRepair.images[2];
    }

    private void UpdatedWord()
    {
        float percentage = ((float) currentLetter)/((float) objectToRepair.name.Length);
        if (percentage >= 0.5f)
        {
            objectSprite.sprite = objectToRepair.images[1];
        }
    }
}
