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
 

    void Start()
    {
        //Timer Begins at time between waves
        waveTimer = timeBetweenWaves;
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
            //Spawn Wave
            spawnGameObject(waves[currentWave].gameObject);
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
}
