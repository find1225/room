using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    //ゴールしてから遷移する
    bool goal_ = false;
    int change_time = 1;
    float elapsed_time = 0;

    [Header("フェイド用パネル")]
    [SerializeField] GameObject Panelfade;

    [Header("チュートリアル")]
    [SerializeField] GameObject tutorial;

    Image fade_alqha;//アルファ値取得用
    float alqha;//アルファ値用
    bool fade_out = false;//フェイド用フラグ

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fade_out = true;
            goal_ = true;
        }
    }

    private void Start()
    {
        Panelfade.SetActive(false);
        fade_alqha = Panelfade.GetComponent<Image>();
        alqha = fade_alqha.color.a;
    }

    private void Update()
    {
        if (fade_out is true) { Fade_Out(); }
        if (goal_ is true)
        {
            if (tutorial != null) { tutorial.SetActive(false); }
            elapsed_time += Time.deltaTime;
            if (change_time <= elapsed_time)
            {
                Stage_number.Number++;//次のシーンナンバーになる
                SceneManager.LoadScene(Stage_number.Number);
            }
        }
    }

    void Fade_Out()
    {
        Panelfade.SetActive(true);
        alqha += 0.01f;
        fade_alqha.color = new Color(0, 0, 0, alqha);
        if (alqha >= 1) { fade_out = false; }
    }
}
