using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spareggio : MonoBehaviour
{
    public GameObject spareggioMenu;
    public GameObject timerAndPoints;
    public Precipitate[] images;
    public WordCompleter[] completers;
    
    public void OnSpareggio()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void LastWord()
    {
        //spegnere spareggio menu
        spareggioMenu.SetActive(false);
        //spegnere timer e punteggio
        timerAndPoints.SetActive(false);
        //riportare immagini in alto
        for (int i = 0; i < images.Length; i++)
        {
            images[i].Reset();
        }
        
        //trovare una nuova parola per entrambi
        //far ripartire i completers
        for (int i = 0; i < completers.Length; i++)
        {
            completers[i].setObjectToRepair(WordsManager.Instance.extractNewObject(completers[i].red));
            completers[i].isSpareggioTime = true;
        }
    }
}
