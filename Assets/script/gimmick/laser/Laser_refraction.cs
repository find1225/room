using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_refraction : MonoBehaviour
{
    [Header("レーザーに関するもの")]
    [SerializeField, Tooltip("レーザーの開始地点")] Transform Lo;
    [SerializeField, Tooltip("Rayの長さ")] float Ray_range;
    [SerializeField, Tooltip("表示用レーザー")] GameObject Laser_obj;
    [SerializeField, Tooltip("ひとつ前のレーザー")] GameObject Laser_ago;
    [SerializeField, Tooltip("レーザーの方向")] Vector3 Laser_directions;

    //------------------------------
    //グローバル変数

    int direction_check = 0;//どの方向に伸ばすのかの確認
    public bool hit_check = false;//何かにヒットしたかの確認

    private void Start()
    {
        if (Laser_directions.x != 0)
        {
            direction_check = 0;
        }
        else if (Laser_directions.y != 0)
        {
            direction_check = 1;
        }
        else { direction_check = 2; }
    }
    void Update()
    {
        //表示されているレーザーの取得および変更
        LineRenderer line = Laser_obj.GetComponent<LineRenderer>();
        line.SetPosition(1, new Vector3(0, 0, 0));

        //ステージに２つ以上のレーザーがあるときの対策if文
        if (Laser_ago.GetComponent<Laser_refraction>().hit_check is true)
        {
            //Rayを飛ばす
            Ray ray = new Ray(Lo.position, Laser_directions);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Ray_range))
            {
                if (hit.collider.gameObject.CompareTag("target"))
                {
                    //Rayが指定オブジェクトに当たったとき
                    //Hitしたことをgateに伝える
                    //ラインラインレンダラーの長さを変える
                    hit_check = true;
                    line.SetPosition(1, new Vector3(
                        hit.point.x - Lo.position.x,
                        hit.point.y - Lo.position.y,
                        hit.point.z - Lo.position.z));
                }
                else
                {
                    //指定以外でもあたった者の長さになる
                    line.SetPosition(1, new Vector3(
                        hit.point.x - Lo.position.x,
                        hit.point.y - Lo.position.y,
                        hit.point.z - Lo.position.z));
                }
            }
        }
    }
}
