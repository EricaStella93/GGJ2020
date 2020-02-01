﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        if (!PointManager.Instance.isDraw())
        {
            source.Stop();
        }
        //TODO fermarla dopo la parola di spareggio
    }
}
