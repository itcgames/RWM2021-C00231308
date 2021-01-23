using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SpawnPositionTests
    {
        //private WaveSpawner waveSpawner;
        public GameObject game;

        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("Spawner", LoadSceneMode.Additive);
        }

        [TearDown]
        public void Teardown()
        {
            //Destroy All Objects in the scene
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                Object.Destroy(o);
            }
            //Unload the Scene on Completion
            SceneManager.UnloadSceneAsync("Spawner");
        }

        [UnityTest]
        public IEnumerator spawnInCorrectPositionsTest()
        {
            yield return new WaitForSeconds(3);

            // if()

            //Make 3 new Type
            GameObject[] gameObj = { new GameObject(), new GameObject(), new GameObject()};

            bool positionCorrect = false;

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("PepeLaugh").Length; i++)
            {
                gameObj[i] = GameObject.FindGameObjectsWithTag("PepeLaugh")[i];
            }

            for(int i = 0; i < gameObj.Length; i++)
            {
                if(gameObj[i].transform.position.x == 3)
                {
                    positionCorrect = true;
                }  
            }


            Assert.True(positionCorrect);
        }
    }


}
