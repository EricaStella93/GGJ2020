using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Precipitate : MonoBehaviour
{
    private bool active = false;
    public float speed = 3.0f;
    public float acc = 2.0f;

    public float damp = 0.3f;

    public float targetY = 255; //to change later?

    private Image image;

    public TextMeshProUGUI endText;

    public GameObject canvasReplay;

    public bool red;

    RectTransform rectTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            rectTransform.localPosition += Vector3.down * speed * Time.deltaTime;
            speed += acc;
            if(rectTransform.localPosition.y <= targetY && speed > 0)
            {
                speed = -1*damp*speed;
                if(Mathf.Abs(speed) < 5f)
                {
                    speed = 0;
                    canvasReplay.SetActive(true);
                }
            }

        }
    }

    public void Activate()
    {
        Debug.Log("Activate");
        active = true;
        if (PointManager.Instance.isDraw())
        {
           endText.text = "Draw";
           //TODO start spareggio
            return;
        }
        if(PointManager.Instance.redWinning() == red)
        {
            endText.text = "Ya winn!";
        }
        else
        {
            endText.text = "Ya lose!";
        }
    }
}
