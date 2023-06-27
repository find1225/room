using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Header("回転対象object")]
    [SerializeField] Transform tr;
    [Header("回転時間(1°ごと)")]
    [SerializeField] float rotate_time;//1度動かすのにかかる時間
    [Header("リセットするオブジェクト")]
    [SerializeField]
    Transform[] reset_obj;

    public AudioClip SE;
    public AudioClip Rotation_SE;

    public AudioSource audioSource;

    List<Vector3> vector3s = new List<Vector3>();
    public bool CoroutineBool = false;//回転するためのコルーチンの制御ブール
    bool rotatable = false;//回転できるかどうか
    public static bool rotatable_share = false;
    bool in_range = false;
    public pause pause;
    PlayerInputSystem playerInputSystem;
    private void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Enable();
        audioSource = GetComponent<AudioSource>();
        if (reset_obj != null)
        {
            for (int i = 0; i < reset_obj.Length; i++)
            {
                vector3s.Add(reset_obj[i].position);
            }
        }
    }
    void Update()
    {
        if (rotatable == true)//回転操作が可の時
        {
            if (playerInputSystem.Player.LeftRool.triggered)
            {
                if (!CoroutineBool)
                {
                    audioSource.Stop();
                    CoroutineBool = true;
                    if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(Rotation_SE);
                    }
                    StartCoroutine("Right_Move");//回転
                }
            }
            if (playerInputSystem.Player.RightRool.triggered)
            {
                if (!CoroutineBool)
                {
                    audioSource.Stop();
                    CoroutineBool = true;
                    if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(Rotation_SE);
                    }
                    StartCoroutine(("Left_Move"));
                }
            }
            if (playerInputSystem.Player.Reset.triggered && reset_obj != null)
            {
                StopCoroutine("Right_Move");
                StopCoroutine("Left_Move");
                CoroutineBool = false;
                tr.rotation = new Quaternion(0, 0, 0, 0);
                audioSource.Stop();
                for (int indx = 0; indx < reset_obj.Length; indx++)
                {
                    reset_obj[indx].position = vector3s[indx];
                }
            }
        }

        if (in_range == true)//柱の範囲に入っているとき
        {
            rotatable = true;//回転の操作切り替え：可
            rotatable_share = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
        if (pause.isPaused is true)
        {
            audioSource.Stop();
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
        audioSource.Stop();
    }

    IEnumerator Left_Move()//左回転
    {
        for (int turn = 0; turn < 90; turn++)
        {
            tr.Rotate(0, 0, -1);
            yield return new WaitForSeconds(rotate_time);
        }
        CoroutineBool = false;
        audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other) //柱の範囲に入ったとき
    {
        if (other.transform.CompareTag("Player"))
        {
            in_range = true;
        }
    }
    private void OnTriggerExit(Collider other)//柱の範囲から出た時
    {
        if (other.transform.CompareTag("Player"))
        {
            rotatable = false;
            rotatable_share = false;
            in_range = false;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
