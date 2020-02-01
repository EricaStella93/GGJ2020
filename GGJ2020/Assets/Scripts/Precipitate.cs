using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Precipitate : MonoBehaviour
{
    private bool active = false;
    public float speed = 3.0f;
    public float acc = 2.0f;

    public float damp = 0.3f;

    public float targetY = 255; //to change later?

    private Image image;

    public Sprite winSprite;
    public Sprite loseSprite;

    public bool red;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
                            
        if(active)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            speed += acc;
            if(transform.position.y <= targetY && speed > 0)
            {
                speed = -1*damp*speed;
            }

        }
    }

    public void Activate()
    {
        active = true;
        if(PointManager.Instance.redWinning() == red)
        {
            image.sprite = winSprite;
        }
        else
        {
            image.sprite = loseSprite;
        }
    }
}
