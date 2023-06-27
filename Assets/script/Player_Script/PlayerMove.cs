using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移動速度
    public float jumpForce = 10.0f; // ジャンプ力

    private Rigidbody rb; // Rigidbodyコンポーネントの参照
    private bool isGrounded = true; // 地面に接地しているかどうかのフラグ
    PlayerInputSystem playerInputSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントの取得
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Enable();
    }

    void Update()
    {
        var playerInput = playerInputSystem.Player.Move.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(playerInput.x, 0, playerInput.y); // 入力された方向をVector3に変換

        if (moveDirection.magnitude >= 0.1f) // 入力がある場合
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection); // 入力方向を見るような回転を計算
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f); // 現在の角度から目標の角度に徐々に回転させる
        }
        else
        {
            // 入力が一定以下の場合は回転をとめる
            rb.angularVelocity = Vector3.zero;
        }

        if (playerInputSystem.Player.jump.triggered && isGrounded) // ジャンプボタンが押された場合かつ接地している場合
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // ジャンプする
            isGrounded = false; // 地面から離れたのでフラグをfalseにする
        }
    }

    void FixedUpdate()
    {
        var playerInput = playerInputSystem.Player.Move.ReadValue<Vector2>();

        if (isGrounded)
            rb.velocity = new Vector3(playerInput.x * moveSpeed, rb.velocity.y, playerInput.y * moveSpeed); // 移動する
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f) // 地面に接地した場合
            {
                isGrounded = true; // 地面に接地したのでフラグをtrueにする
            }
        }
    }
}
