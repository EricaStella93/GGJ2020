using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeTween : MonoBehaviour
{
    public float time;
    private float timeCurrent;


    public AnimationCurve curveX = AnimationCurve.Linear(0, 0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = curveX.Evaluate(timeCurrent);
        timeCurrent += time;
        transform.localScale = new Vector3(value,value,value);
    }

    public void restart()
    {
        timeCurrent = 0.0f;
    }
}
