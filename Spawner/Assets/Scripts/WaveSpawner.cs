using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Wave Timer
    public float timeBetweenWaves = 10;
    float waveTimer;
    
    //Waves
    public Wave[] waves;
    int currentWave = 0;

    //Progress Bar
    //public ProgressBar progressBar;
    public ProgressBar pb;
    private float totalTime;
    float oneSecondAsPercentage;

    //Heavy Spawn indicator Varibles
    float widthProgressBar;
    float heightProgressBar;



    void Start()
    {
        //Timer Begins at time between waves
        waveTimer = timeBetweenWaves;

        //Get total Time
        totalTime = waves.Length * timeBetweenWaves;

        //Get one second as a Percentage
         oneSecondAsPercentage = 100 / totalTime;

        //Assign width of progress bar
        widthProgressBar = pb.transform.GetComponent<RectTransform>().sizeDelta.x;
        //Assign Height of progress bar
        heightProgressBar = pb.transform.GetComponent<RectTransform>().sizeDelta.y;

        for(int i = 0; i < waves.Length; i++ )
        {
            if(waves[i].heavyWave)
            {
                float xPos = (widthProgressBar / waves.Length) * i + (pb.transform.position.x - (widthProgressBar / 2));
                float yPos = pb.transform.position.y + (heightProgressBar);
               // float xPos = (widthProgressBar / (timeBetweenWaves )* i) + (pb.transform.position.x - (widthProgressBar/2));
                //float yPos = (heightProgressBar) + (pb.transform.position.y - (heightProgressBar/2));

                //float yPos = 1000;
                //float xPos = 0;

                pb.placeHeavyWaveMarker(xPos, yPos);

            }
        }


        //Update Progress Bar
        StartCoroutine(updateProgressBar());

    }

    void Update()
    {
        //Spawn Wave after Timer reaches zero
        if(waveTimer <= 0)
        {
            //Spawn the wave and reset time
            spawnWave();
            resetTimer();
        }
        //If Wave Timer is above zero take away time
        else if (waveTimer > 0)
        {
            //Take away deltaTime to countdown Wave Timer
            waveTimer -= Time.deltaTime;
        }


    }

    void spawnWave()
    {
        //Check current wave isnt the last
        if(currentWave < waves.Length)
        {
            //Spawn Amount of objects that are in the current Wave
            for (int i = 0; i < waves[currentWave].amountOfObjects; i++ )
            {
                spawnGameObject(waves[currentWave].gameObject);
            }

            //Increase Current Wave
            currentWave++;
        }
        else
        {
            //Finished Spawning
        }
    }

    void spawnGameObject(GameObject gameObject)
    {
        //instantiate the gameObject
        Instantiate(gameObject);
    }

    void resetTimer()
    {
        //Reset Timer
        waveTimer = timeBetweenWaves;
    }

    IEnumerator updateProgressBar()
    {
        while(true)
        {
            //Update the bar every second
            yield return new WaitForSeconds(1f);
            //progressBar.increaseProgress(oneSecondAsPercentage);
            pb.increaseProgress(oneSecondAsPercentage);
        }
    }
}
