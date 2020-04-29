using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnGo : MonoBehaviour
{
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public async void BtnClickGoAsync()
    {
        for (int i = 3; i > 0; --i)
        {
            txt.text = i.ToString();
            await Task.Delay(500);
            txt.text = "";
            await Task.Delay(500);
        }
        txt.text = "GO!";
        await Task.Delay(500);
        txt.text = "";
        SceneManager.LoadScene("_Scene_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
