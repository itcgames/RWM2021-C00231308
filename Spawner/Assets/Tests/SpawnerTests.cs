using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SpawnTests
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


        //Check Timer Is Spawning Correctly
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

        //Check Ammount of waves are Spawning Correctly
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

        //Check Game Object Type
        [UnityTest]
        public IEnumerator gameObjectTest()
        {
            //Make Gameobject Type
            GameObject gameObjType = new GameObject();
            //Wait till gameobject spawns
            yield return new WaitForSeconds(3);
            //Check the types are the same
            Assert.True(GameObject.Find("pepelaugh(Clone)").GetType() == gameObjType.GetType());
        }
    }
}
