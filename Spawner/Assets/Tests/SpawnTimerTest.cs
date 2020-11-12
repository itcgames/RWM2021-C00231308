using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SpawnTimerTest
    {
        //private WaveSpawner waveSpawner;
        public GameObject game;

        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("Demo", LoadSceneMode.Additive);
            //Create Spawner in the Scene
            game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        }

        [TearDown]
        public void Teardown()
        {
            //Destroy the Spawner
            Object.Destroy(game);
            //Unload the Scene on Completion
            SceneManager.UnloadSceneAsync("Demo");
        }


        [UnityTest]
        public IEnumerator spawnTimerTest()
        {
            //Wait one second (First spawn on 2 seconds so assert should return false)
            yield return new WaitForSeconds(1);
            Assert.False(GameObject.Find("pepelaugh(Clone)"));
            //Wait two more seconds (Spawn Should now have happened)
            yield return new WaitForSeconds(2);
            Assert.True(GameObject.Find("pepelaugh(Clone)"));
        }

        [UnityTest]
        public IEnumerator waveNumberTest()
        {
            //First Wave Check
            yield return new WaitForSeconds(3);
            Assert.True(GameObject.Find("pepelaugh(Clone)"));
            //Second Wave Check
            yield return new WaitForSeconds(3);
            Assert.True(GameObject.Find("sadge(Clone)"));

        }


    }
}
