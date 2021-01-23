using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public bool turnOn = true;

    public static Timer timer;
    public Text timeText;
    private TimeSpan timePlaying;
    bool timeBegan = false;

    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        if(turnOn)
        {
            this.gameObject.SetActive(true);
            timeText.text = "Time: 00:00:00";
            timeBegan = false;
            startTimer();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void startTimer()
    {
        timeBegan = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }


    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator UpdateTimer()
    {
        //If timer has started
        while (timeBegan)
        {
            //Add Time to Elapsed Time
            elapsedTime += Time.deltaTime;
            //Converts to time span instance
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            //Display and formatting
            string timePlayingStr = "Time:" + timePlaying.ToString("mm' : 'ss' : 'ff");
            //Assign to UI text
            timeText.text = timePlayingStr;

            yield return null;
        }
    }

}
