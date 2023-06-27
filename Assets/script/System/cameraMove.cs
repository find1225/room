using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    //カメラがプレイヤーを追従するだけのスクリプト
    [Header("主人公")]
    [SerializeField]Transform player;
    [Header("カメラ")]
    [SerializeField]Transform camera_;

    // Update is called once per frame
    void Update()
    {
        camera_.position = new Vector3(0,3.5f,player.position.z - 5);
    }
}
