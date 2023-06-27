using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //falseゲートを閉める trueゲートを開ける
    public bool hit_check = false;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("block"))
        {
            hit_check = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("block"))
        {
            hit_check = false;
        }
    }
}
