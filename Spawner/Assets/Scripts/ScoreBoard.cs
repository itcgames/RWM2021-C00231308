using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct ScoreBoardInfo
{
    public string name;
    public int enemiesKilled;
    public double time;
}

public class ScoreBoard : MonoBehaviour
{
    //Transform Container
    public Transform transformContainer;
    //Entry
    public Transform entry;

    //Max Scores showing
    public int maxEntrys = 5;

    //Height of Entry
    float heightOfEntry;

    //List of ScoreboardInfo
    private List<ScoreBoardInfo> scoreboardListInfo;
    private List<Transform> scoreboardListTransform;

    private void Awake()
    {
        //Dont show template score entry
        entry.gameObject.SetActive(false);

        //Get Height of score entrys
        heightOfEntry = entry.transform.GetComponent<RectTransform>().sizeDelta.y;

        //Fill list with default values
        scoreboardListInfo = new List<ScoreBoardInfo>()
        {
            new ScoreBoardInfo { name = "Tom", time = Random.Range(0,1000), enemiesKilled = Random.Range(0,50) },
            new ScoreBoardInfo { name = "Joe", time = Random.Range(0,1000), enemiesKilled = Random.Range(0,50) },
            new ScoreBoardInfo { name = "Shaun", time = Random.Range(0,1000), enemiesKilled = Random.Range(0,50) },
            new ScoreBoardInfo { name = "Robbin", time = Random.Range(0,1000), enemiesKilled = Random.Range(0,50) },
            new ScoreBoardInfo { name = "Peter", time = Random.Range(0,1000), enemiesKilled = Random.Range(0,50) },
        };


        //sortListByTime();
        scoreboardListTransform = new List<Transform>();

        ScoreBoardInfo newScore;
        newScore.name = "You";
        newScore.time = Random.Range(0, 1000);
        newScore.enemiesKilled = Random.Range(0, 50);

        //Enter Players score
        playerEntry(newScore);
    }

    private void highScoreEntry(ScoreBoardInfo scoreBoardInfo, Transform container, List<Transform> transforms )
    {
        Transform entryTransform = Instantiate(entry, container);
        RectTransform entryrect = entryTransform.GetComponent<RectTransform>();
        entryrect.anchoredPosition = new Vector2(0, -(transforms.Count) * heightOfEntry);
        entryTransform.gameObject.SetActive(true);

        //Fill with Test Values
        entryTransform.Find("Name").GetComponent<Text>().text = scoreBoardInfo.name;
        entryTransform.Find("Time").GetComponent<Text>().text = scoreBoardInfo.time.ToString();
        entryTransform.Find("Kills").GetComponent<Text>().text = scoreBoardInfo.enemiesKilled.ToString();

        transforms.Add(entryTransform);
    }

    private void sortListByTime()
    {
        //Sort the times highest to Time
        for (int i = 0; i < scoreboardListInfo.Count; i++)
        {
            for (int j = i + 1; j < scoreboardListInfo.Count; j++)
            {
                if (scoreboardListInfo[j].time > scoreboardListInfo[i].time)
                {
                    //Swap the placements
                    //Temp to hold the info while it is changed over
                    ScoreBoardInfo tempHolder = scoreboardListInfo[i];
                    //Swaping list info palces
                    scoreboardListInfo[i] = scoreboardListInfo[j];
                    scoreboardListInfo[j] = tempHolder;
                }
            }
        }
    }

    public void playerEntry(ScoreBoardInfo playersInfo)
    {
        //Add the players info to the list
        scoreboardListInfo.Add(playersInfo);

        //sort the list relative to Time (Longer is better) 
        sortListByTime();
        
        //Create an entry for each of the scores info in the list depending on max entrys
        for(int i = 0; i < maxEntrys; i++)
        {
            highScoreEntry(scoreboardListInfo[i], transformContainer, scoreboardListTransform);
        }

    }
}
