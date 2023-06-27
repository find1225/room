using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{

    bool isGrounded;
    Animator animator;
    public AudioClip moveSE;
    public AudioClip jumpSE;
    private AudioSource audioSource;
    PlayerInputSystem playerInputSystem;

    void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Enable();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //ジャンプしたとき
        if (playerInputSystem.Player.jump.triggered)
        {
            jump();
        }
    }
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        var playerInput = playerInputSystem.Player.Move.ReadValue<Vector2>();

        if (isGrounded == true)
        {
            //止まっているとき
            if (Horizontal == 0 && Vertical == 0)
            {
                audioSource.Stop();
                animator.Play("Sad Idle");
                animator.SetBool("IsMoving", false);
                animator.SetBool("IsJump", false);
            }
            else
            {
                //動いてる時
                if (!audioSource.isPlaying)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(moveSE);
                }
                animator.Play("Walking");
                animator.SetBool("IsMoving", true);
                animator.SetBool("IsJump", false);
            }
            //ジャンプしたとき
            if (playerInputSystem.Player.jump.triggered)
            {
                isGrounded = false;
                audioSource.Stop();
            }
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(jumpSE);
            }
            animator.Play("Jumping");
            animator.SetBool("IsJump", true);
            animator.SetBool("IsMoving", false);
        }
    }
    void jump()
    {
        isGrounded = false;
        audioSource.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(jumpSE);
        }
        animator.Play("Jumping");
        animator.SetBool("IsJump", true);
        animator.SetBool("IsMoving", false);
    }
    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        audioSource.Stop();
    }
}
