using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordCompleter : MonoBehaviour
{
    public Image objectSprite;
    
    private RepairableObject objectToRepair;

    private bool blockInput = false;

    private int count; //number of letters in the object

    public bool red;
    private int currentLetter = 0; //how many letters already typed

    public TextMeshProUGUI text;

    public float pause = 0.2f;

    private SizeTween textTween;

    void Start()
    {
      textTween = text.gameObject.GetComponent<SizeTween>();  
    }
    
    void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey && !WordsManager.Instance.isTimerOver() && !blockInput)
            {
                if(Char.ToLower(e.character) == Char.ToLower(objectToRepair.name[currentLetter]))
                {
                    currentLetter++;
                    text.text = "<color=#ff9300>";
                    for(int i = 0; i < count; i++)
                    {
                        text.text += objectToRepair.name[i];
                        if(i == currentLetter-1)
                        {
                            text.text += "</color><color=#18247C>";
                        }
                    }
                    text.text += "</color>";
                    if(currentLetter >= count)
                    {
                       blockInput = true;
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
        text.text = "<color=#18247C>"+objectToRepair.name+"</color>";
        currentLetter = 0;
        count = newObject.name.Length;
        blockInput = false;
        textTween.restart();
    }

    private void FinishedWord()
    {
        objectSprite.sprite = objectToRepair.images[2];
    }

    private void UpdatedWord()
    {
        float percentage = ((float) currentLetter)/((float) objectToRepair.name.Length);
        if (percentage >= 0.5f && objectSprite.sprite != objectToRepair.images[1])
        {
            objectSprite.sprite = objectToRepair.images[1];
            SfxManager.Instance.PlayHalfWordClip();
        }
        else
        {
            SfxManager.Instance.PlayLetterAcceptedClip();
        }
    }
}
