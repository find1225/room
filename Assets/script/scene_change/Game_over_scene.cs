using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over_scene : MonoBehaviour
{
    //ゲームオーバーscene用
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("menu");
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(Stage_number.Number);
        }
    }
    public void menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(Stage_number.Number);
    }
}
