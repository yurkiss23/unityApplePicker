using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public List<float> listLevelData = new List<float> { 2f, 4f, 6f, 8f, 10f, 11f, 12f, 13f, 14f, 15f };
    public int[] levelArr = new int[] { 0, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500 };
    public Text levels, score, levelInfo;
    public int lvl;

    // Start is called before the first frame update
    void Start()
    {
        levelInfo = GameObject.Find("txtLvlInfo").GetComponent<Text>();
        levelInfo.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject scoreCounter = GameObject.Find("ScoreCounter");
        levels = GameObject.Find("txtLevel").GetComponent<Text>();
        score = scoreCounter.GetComponent<Text>();
        for (int i = 0; i < 10; ++i)
        {
            if (int.Parse(score.text) == levelArr[i])
            {
                lvl = i + 1;
                AppleTree.speed = listLevelData[i];
                levels.text = "level: " + lvl;

                LevelInfoAsync();
            }
        }
    }

    public async void LevelInfoAsync()
    {
        levelInfo.text = lvl.ToString();
        await Task.Delay(700);
        levelInfo.text = "";
    }
}
