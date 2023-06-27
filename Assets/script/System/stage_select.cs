using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_select : MonoBehaviour
{
    [Header("移動するUI")]
    [SerializeField] GameObject[] gameObjects;
    [SerializeField, Tooltip("みぎ")] GameObject right_;
    [SerializeField, Tooltip("ひだり")] GameObject left_;
    int count = 0;
    void Awake()
    {
        Rotation.rotatable_share = false;
    }
    private void Start()
    {
        Screen.SetResolution(800, 800, false);
        left_.SetActive(false);
    }
    public void Stage1()
    {
        Stage_number.Number = 2;
        SceneManager.LoadScene(2);
    }

    public void Stage2()
    {
        Stage_number.Number = 3;
        SceneManager.LoadScene(3);
    }

    public void Stage3()
    {
        Stage_number.Number = 4;
        SceneManager.LoadScene(4);
    }

    public void Stage4()
    {
        Stage_number.Number = 5;
        SceneManager.LoadScene(5);
    }

    public void Stage5()
    {
        Stage_number.Number = 6;
        SceneManager.LoadScene(6);
    }

    public void Stage6()
    {
        Stage_number.Number = 7;
        SceneManager.LoadScene(7);
    }

    public void Stage7()
    {
        Stage_number.Number = 8;
        SceneManager.LoadScene(8);
    }

    public void Stage8()
    {
        Stage_number.Number = 9;
        SceneManager.LoadScene(9);
    }
    public void Stage9()
    {
        Stage_number.Number = 10;
        SceneManager.LoadScene("Stage7");
    }
    public void Stage10()
    {
        Stage_number.Number = 11;
        SceneManager.LoadScene("Stage8");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void Next()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 pos = new Vector3(
                gameObjects[i].transform.position.x - 700,
                gameObjects[i].transform.position.y,
                gameObjects[i].transform.position.z);
            gameObjects[i].transform.position = pos;
        }
        count++;
    }

    public void Back()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 pos = new Vector3(
                gameObjects[i].transform.position.x + 700,
                gameObjects[i].transform.position.y,
                gameObjects[i].transform.position.z);
            gameObjects[i].transform.position = pos;
        }
        count--;
    }
    private void Update()
    {
        switch (count)
        {
            case 0:
                right_.SetActive(true);
                left_.SetActive(false);
                break;
            case 1:
                right_.SetActive(false);
                left_.SetActive(true);
                break;
                // case 2:
                //     right_.SetActive(false);
                //     left_.SetActive(true);
                //     break;
        }
    }
}
