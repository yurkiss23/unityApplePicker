using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] //Розділ, де будуть відображаться змінні, значення яких визначається в ході ігри
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //видаляємо усі упавші яблука
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //Удаляємо одну корзину
        //Отримуємо індекс останьої коризини в спивку корзин
        int basketIndex = basketList.Count - 1;
        //Отримуємо силку на ігровий обєкт Basket
        GameObject tBasketGo = basketList[basketIndex];
        //Видаляємо корзину із списку і видаляємо сам ігровий обєкт
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_End");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
