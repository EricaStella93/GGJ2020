using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitching : MonoBehaviour
{
    private Image image;

    public Sprite image1;
    public Sprite image2;

    private int currentSprite = 1;

    public int frameSkip = 10;

    private int currentFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentFrame++;
        if(currentFrame >= frameSkip)
        {
            currentFrame = 0;
            if(currentSprite == 1)
            {
                currentSprite = 2;
                image.sprite = image2;
            }
            else if(currentSprite == 2)
            {
                currentSprite = 1;
                image.sprite = image1;
            }
        }
    }
}
