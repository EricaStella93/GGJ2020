using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCompleter : MonoBehaviour
{
    private RepairableObject objectToRepair;

    private int count; //number of letters in the object

    public bool red;
    private int currentLetter = 0; //how many letters already typed

    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
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
                        //POINT HERE
                        if(!WordsManager.Instance.isTimerOver())
                            setObjectToRepair(WordsManager.Instance.extractNewObject(red));
                            
                    }
                }
            }
        }

    public void setObjectToRepair(RepairableObject newObject)
    {
        objectToRepair = newObject;
        text.text = objectToRepair.name;
        currentLetter = 0;
        count = newObject.name.Length;
    }
}
