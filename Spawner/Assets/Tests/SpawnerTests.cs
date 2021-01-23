using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class EndlessSpawnerTests
    {
        //private WaveSpawner waveSpawner;
        public GameObject game;

        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("EndlessSpawner", LoadSceneMode.Additive);
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
            SceneManager.UnloadSceneAsync("EndlessSpawner");
        }


        [UnityTest]
        public IEnumerator initalSpawnTimerTest()
        {
            //Wait four second (First spawn on 5 seconds so assert should return false)
            yield return new WaitForSeconds(4);
            //Assert Neither gameobject has been found
            Assert.False(GameObject.Find("pepelaugh(Clone)"));
            Assert.False(GameObject.Find("sadge(Clone)"));

            yield return new WaitForSeconds(2);

            //Wait two more seconds (Spawn Should now have happened)
            bool spawnHappened = false;
            if (GameObject.Find("pepelaugh(Clone)") || GameObject.Find("sadge(Clone)"))
            {
                spawnHappened = true;
            }
            else
            {
                //Remain False
            }

            if (spawnHappened)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }



        //Check Game Object Type
        [UnityTest]
        public IEnumerator gameObjectTest()
        {
            //Make Gameobject Type
            GameObject gameObjType = new GameObject();
            //Wait till gameobject spawns
            yield return new WaitForSeconds(6);
            //Check the types are the same
            if (GameObject.Find("pepelaugh(Clone)"))
            {
                Assert.True(GameObject.Find("pepelaugh(Clone)").GetType() == gameObjType.GetType());
            }
            else if (GameObject.Find("sadge(Clone)"))
            {
                Assert.True(GameObject.Find("sadge(Clone)").GetType() == gameObjType.GetType());
            }
            else
            {
                //Remain False
                Assert.Fail();
            }           
        }
    }
}
