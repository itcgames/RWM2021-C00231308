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

    //Wave
    public Wave wave;

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
            //Spawn the wave
            spawnWave();
            waveTimer = timeBetweenWaves;
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
        //Spawn the GameObject inside the Wave
        spawnGameObject(wave.gameObject);
    }

    void spawnGameObject(GameObject gameObject)
    {
        //instantiate the gameObject
        Instantiate(gameObject);
    }
}
