using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace Tests
{
    public class ScoreboardTests
    {

        public GameObject scoreboard;

        [SetUp]
        public void Setup()
        {
            //Load Demo Scene
            SceneManager.LoadScene("ScoreBoardDemo", LoadSceneMode.Additive);
            scoreboard = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ScoreBoardCanvas"));
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
            SceneManager.UnloadSceneAsync("ScoreBoardDemo");
        }

        [UnityTest]
        public IEnumerator scoreboardAmount()
        {

            yield return new WaitForSeconds(1);
            int amountOfEntrys = GameObject.FindGameObjectsWithTag("ScoreboardEntry").Length;
            int maxEntrysSelected = scoreboard.GetComponentInChildren<ScoreBoard>().maxEntrys;
            if ( amountOfEntrys == maxEntrysSelected )
            {
                Assert.Pass();
            }
            else
            {
               
                Assert.Fail();
            }
        }
    }
}
