using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug_Rotation : MonoBehaviour
{
    //新規ステージ作成時に使用
    [Header("回転対象object")]
    [SerializeField] Transform tr;
    [Header("回転時間(1°ごと)")]
    [SerializeField] float rotate_time;
    bool CoroutineBool = false;//回転制御用
    bool rotatable = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (!CoroutineBool)
            {
                CoroutineBool = true;
                StartCoroutine("Right_Move");
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (!CoroutineBool)
            {
                CoroutineBool = true;
                StartCoroutine("left_Move");
            }
        }
    }
    IEnumerator Right_Move()//右回転
    {
        for (int turn = 0; turn < 90; turn++)
        {
            tr.Rotate(0, 0, 1);
            yield return new WaitForSeconds(rotate_time);
        }
        CoroutineBool = false;
    }



    IEnumerator left_Move()//右回転
    {
        for (int turn = 0; turn < 90; turn++)
        {
            tr.Rotate(0, 0, -1);
            yield return new WaitForSeconds(rotate_time);
        }
        CoroutineBool = false;
    }
}
