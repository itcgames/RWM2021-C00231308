using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessWaveSpawner : MonoBehaviour
{
    public GameObject[] Object;

    private Wave[] waves;

    //Wave Timer
    float initialTimer = 0;
    public float initialSetUpTime = 5;

    public float timeBetweenWaves;
    float waveTimer;

    //Waves
    int currentWave = 0;

    //Poisitions
    public Vector3[] spawnPositions;

    //Amount Per Wave
    public int minAmountPerWave;
    public int maxAmountPerWave;

    //Decreasing Wave Timer
    public float decreasingWaveTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    void start()
    {
        //Timer Begins at time between waves
        waveTimer = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialTimer < initialSetUpTime)
        {
            initialTimer += Time.deltaTime;
        }
        else
        {
            //Spawn Wave after Timer reaches zero
            if (waveTimer <= 0)
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

    }

    void spawnWave()
    {
        //Create New Wave
        Wave newWave = new Wave();

        //Assign name
        newWave.waveName = "New Wave";
        //Assign amount of zombies in the wave
        newWave.amountOfObjects = Random.Range(minAmountPerWave, maxAmountPerWave);

        //Random Game Object
        int gameObjectSelector = Random.Range(0, Object.Length);

        newWave.gameObject = Object[gameObjectSelector];
       
        for (int i = 0; i < newWave.amountOfObjects; i++)
        {
            Vector3 spawnVec = positionGenerator();

            //instantiate the gameObject
            Instantiate(newWave.gameObject, spawnVec, Quaternion.identity);
        }

        //Increase Current Wave
        currentWave++;

        if (timeBetweenWaves >= 2)
        {
            timeBetweenWaves -= decreasingWaveTimer;
        }


    }
    void resetTimer()
    {
        //Reset Timer
        waveTimer = timeBetweenWaves;
    }

    Vector3 positionGenerator()
    {
        Vector3 returnVec = spawnPositions[Random.Range(0, spawnPositions.Length)];

        return returnVec;
    }

}
