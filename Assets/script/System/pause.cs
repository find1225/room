using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    //escape押したらpause画面になる
    public GameObject pause_UIs;
    public bool isPaused = false;
    Rotation rotation;
    PlayerInputSystem playerInputSystem;
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Enable();
        pause_UIs.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputSystem.Player.Pause.triggered)
        {
            print("A");
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pause_UIs.gameObject.SetActive(isPaused);
        }
        if (isPaused)
        {
            if (playerInputSystem.Pause.BackGame.triggered)
            {
                back();
            }
            if (playerInputSystem.Pause.Menu.triggered)
            {
                menu();
            }
        }
    }

    public void menu()
    {
        Time.timeScale = 1;
        isPaused = !isPaused;
        SceneManager.LoadScene(0);
    }

    public void back()
    {
        Time.timeScale = 1;
        pause_UIs.gameObject.SetActive(false);
        isPaused = !isPaused;
    }
}
