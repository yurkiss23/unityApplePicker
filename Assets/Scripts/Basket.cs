using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    static public int yourScore;
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Получить силку на ігровий обєкт ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Получить компонент Text цього ігрового обєкта
        scoreGT = scoreGO.GetComponent<Text>();
        //Встанолюємо початкове значення очків
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Отримати поточні координати мишки на екрані з Input
        Vector3 mousePos2D = Input.mousePosition;

        //Координати Z камери визначаючий, як далеко в трохмірному просторі
        //знаходиться вказівник миші
        mousePos2D.z = -Camera.main.transform.position.z;

        //Перетворити точку на двухмірній площині єкрану в трохмірні коодинати ігри
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Переміщаємо корзину вздовж осі X в координату X вказівника миші
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    //Визивається всякий раз коли який інший обєкт стикається із корзиною
    private void OnCollisionEnter(Collision coll)
    {
        //Пошук яблука, яке попало в корзину
        GameObject collidedWidth = coll.gameObject;  //Обєкт який стикнувся із корзиною
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth); //Якщо облуко то видаємо його
            //Перетворити текст в scoreGT в ціле число
            int score = int.Parse(scoreGT.text);
            //Добавить очки за пойманное яблоко
            score += 10;
            //Перетворити число очків назад в строку і вивести його на екран
            scoreGT.text = score.ToString();
            yourScore = score;

            //Запамятовуємо вище досягнення
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
