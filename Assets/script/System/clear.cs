using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    //クリアしたとき
    public void clear_()
    {
        SceneManager.LoadScene("menu");
    }

    public void exit()
    {
        Application.Quit();
    }
}
