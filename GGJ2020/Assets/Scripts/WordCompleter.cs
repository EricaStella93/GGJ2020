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
                        PointManager.Instance.score(red);
                        FinishedWord();
                        if(!WordsManager.Instance.isTimerOver())
                            setObjectToRepair(WordsManager.Instance.extractNewObject(red));
                            
                    }
                    else
                    {
                        UpdatedWord();
                    }
                }
            }
        }

    public void setObjectToRepair(RepairableObject newObject)
    {
        objectToRepair = newObject;
        objectSprite.sprite = objectToRepair.images[0];
        text.text = objectToRepair.name;
        currentLetter = 0;
        count = newObject.name.Length;
    }

    private void FinishedWord()
    {
        //TODO cambiare immagine + animazione e suoni
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
