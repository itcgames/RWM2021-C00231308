﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public RectTransform Pointer;

    // Start is called before the first frame update
    public void Start()
    {
        slider.value = 0;
    }


    // Update is called once per frame
    public void increaseProgress(float percentComplete)
    {
        slider.value += percentComplete;
    }

    public void placeHeavyWaveMarker(float xPos, float yPos)
    {

        RectTransform flag = Instantiate(Pointer, transform);

        flag.transform.position += new Vector3(xPos, yPos, 0);
    }

}
