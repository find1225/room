using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    //ギミック関連
    [Header("レーザーの開始地点")]
    [SerializeField] Transform Lo;
    [Header("ターゲット")]
    [SerializeField] Transform Tg;
    [Header("rayの長さ")]
    [SerializeField] float Ray_range;
    [Header("レイザーオブジェクト")]
    [SerializeField] GameObject laser_object;
    [Header("表示するレイザーの長さ")]
    [SerializeField] float laser_range;

    //---------------------------
    //グローバル変数
    public bool hit_check = false;

    void Update()
    {

        // //レイザーのテクスチャの長さ変更
        LineRenderer line = laser_object.GetComponent<LineRenderer>();
        line.SetPosition(1, new Vector3(0, 0, laser_range));

        // //ゲートを下げる
        hit_check = false;

        Ray ray = new Ray(Lo.position,new Vector3(0,0,1));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,Ray_range))
        {
            if(hit.collider.gameObject.CompareTag("target"))
            {
                hit_check = true;
                line.SetPosition(1,new Vector3(0,0,Tg.position.z - Lo.position.z));
            }
            else
            {
                hit_check = false;
                line.SetPosition(1,new Vector3(0,0,hit.collider.transform.position.z - Lo.position.z));
            }
        }
    }
}
