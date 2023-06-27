using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
    //ゲームオーバー判定
    [Header("プレイヤー")]
    [SerializeField]Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player.position.y <= -3f)
        {
            SceneManager.LoadScene("Game_over");
        }
    }
}
