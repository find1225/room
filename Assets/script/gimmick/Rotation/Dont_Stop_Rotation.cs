using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Stop_Rotation : MonoBehaviour
{
    //押している間回転するscript
    //基本的な内容は通常の回転と同じ
    [Header("回転対象のオブジェクト")]
    [SerializeField] Transform Target_Obj;

    [Header("リセットするオブジェクト")]
    [SerializeField] Transform[] Reset_obj;

    public AudioClip SE;
    public AudioClip Rotation_SE;

    private AudioSource audioSource;
    List<Vector3> vector3s = new List<Vector3>();

    bool In_Range = false;
    bool Move_ = false;

    bool SE_bool = false;

    public static bool rotatable_share = false;
    PlayerInputSystem playerInputSystem;

    private void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        audioSource = GetComponent<AudioSource>();
        if (Reset_obj != null)
        {
            for (int i = 0; i < Reset_obj.Length; i++)
            {
                vector3s.Add(Reset_obj[i].position);
            }
        }
    }

    void Update()
    {
        if (In_Range)
        {
            if (playerInputSystem.Player.LeftRool.IsPressed())
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(Rotation_SE);
                }
                Target_Obj.Rotate(0, 0, 60 * Time.deltaTime);
                SE_bool = true;
            }
            else if (playerInputSystem.Player.RightRool.IsPressed())
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(Rotation_SE);
                }
                Target_Obj.Rotate(0, 0, -60 * Time.deltaTime);
                SE_bool = true;
            }
            else if (SE_bool is true)
            {
                //SE_bool = false;
                audioSource.Stop();
            }
            if (playerInputSystem.Player.Reset.triggered && Reset_obj != null)
            {
                Target_Obj.rotation = new Quaternion(0, 0, 0, 0);
                for (int indx = 0; indx < Reset_obj.Length; indx++)
                {
                    Reset_obj[indx].position = vector3s[indx];
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Move_ = true;
            In_Range = true;
            rotatable_share = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Move_ = false;
            rotatable_share = false;
            In_Range = false;
            SE_bool = false;
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
