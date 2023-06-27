using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    [Header("移動対象オブジェクト")]
    [SerializeField] Transform Tr;
    [Header("transform上の0.1を動かす時間(0.025)")]
    [SerializeField] float Move_Time;
    [Header("対応するギミック")]
    [SerializeField] GameObject gimmick;
    [SerializeField, Tooltip("falseはレイザー")] bool laser_button = false;
    [Header("チュートリアル用コントロールロット")]
    [SerializeField]Rotation cnt_rot;

    [Header("消すObject")]
    [SerializeField] GameObject block_obj;

    bool Up_Down = false;//現在の状態   false→下がっている  true→上がっている
    bool move_check = false;//動いたかどうか//falseなら動いていない


    void Update()
    {
        if(gimmick != null)
        {
            if (laser_button == false)
            {
                if (gimmick.GetComponent<laser>().hit_check == true && move_check is false)
                {
                    StartCoroutine("Gate_Up");
                }
                else if (gimmick.GetComponent<laser>().hit_check == false && move_check is true)
                {
                    StartCoroutine("Gate_Down");
                }
            }
            else
            {
                if (gimmick.GetComponent<Button>().hit_check == true && move_check is false)
                {
                    StartCoroutine("Gate_Up");
                }
                else if (gimmick.GetComponent<Button>().hit_check == false && move_check is true)
                {
                    StartCoroutine("Gate_Down");
                }
            }
        }
        if(cnt_rot != null)
        {
            if(cnt_rot.CoroutineBool is true)
            {
                StartCoroutine("Gate_Up");
            }
        }
    }

    IEnumerator Gate_Up()//ゲートオープン
    {
        if (Up_Down == false)
        {
            if (block_obj != null) { block_obj.SetActive(false); }
            move_check = true;
            Up_Down = true;
            for (int move_u = 0; move_u < 51; move_u++)
            {
                var move_point = new Vector3(0, 0.1f, 0);
                Tr.position += move_point;
                yield return new WaitForSeconds(Move_Time);
            }
        }
    }

    IEnumerator Gate_Down()//ゲートクローズ
    {
        if (Up_Down == true)
        {
            if (block_obj != null) { block_obj.SetActive(true); }
            move_check = false;
            Up_Down = false;
            for (int move_d = 0; move_d < 51; move_d++)
            {
                var move_point = new Vector3(0, -0.1f, 0);
                Tr.position += move_point;
                yield return new WaitForSeconds(Move_Time);
            }
        }
    }
}