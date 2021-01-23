using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TimerTests
    {
        //private WaveSpawner waveSpawner;
        public GameObject game;
        public Timer timer;

        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("Spawner", LoadSceneMode.Additive);
            //Create Spawner in the Scene
            //game = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            timer = MonoBehaviour.Instantiate(Resources.Load<Timer>("Prefabs/Timer"));
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
        public IEnumerator timerCounting()
        {
            if(timer.elapsedTime > 1)
            {
                Assert.Fail();
            }

            yield return new WaitForSeconds(3);
            if(timer.elapsedTime > 3)
            {
                Assert.Pass();
            }
        }
    }
}
