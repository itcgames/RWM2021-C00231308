using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class ProgressBarTests
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
            //Destroy All Objects in the scene
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
            {
                Object.Destroy(o);
            }
            //Unload the Scene on Completion
            SceneManager.UnloadSceneAsync("Demo");
        }


        //Check Progress Bar is spawning correctly
        [UnityTest]
        public IEnumerator spawnProgressBar()
        {
            //Wait one second for game object to instantiate
            yield return new WaitForSeconds(1);


            Assert.True(GameObject.Find("ProgressBar"));
            Assert.True(GameObject.Find("Boarder"));
            Assert.True(GameObject.Find("WaveProgress"));
        }
    }
}
