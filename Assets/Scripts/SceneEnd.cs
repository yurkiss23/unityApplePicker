using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneEnd : MonoBehaviour
{
    public Text txtScore;

    // Start is called before the first frame update
    void Start()
    {
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        txtScore.text = Basket.yourScore.ToString();
    }

    public void GameOver()
    {
        Application.Quit();
    }

    public void Repeat()
    {
        SceneManager.LoadScene("_Scene_1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
