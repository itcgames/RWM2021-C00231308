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
        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("Demo", LoadSceneMode.Additive);
        }

        [TearDown]
        public void Teardown()
        {
            //Unload the Scene on Completion
            SceneManager.UnloadSceneAsync("Demo");
        }

        [UnityTest]
        public IEnumerator spawnTimerTest()
        {
            yield return new WaitForSeconds(3);
            Assert.True(GameObject.Find("pepelaugh(Clone)"));
        }
    }
}
