using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; 
    public AudioClip coinSoundSource; 
    public AudioClip jumpSound; 

    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false; 
    private bool isDead = false; 

    private Rigidbody2D playerRigidbody; 
    private Animator animator; 
    
    private AudioSource playerAudio; 
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            playerAudio.clip = jumpSound;
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }

    private void Die()
    {
       
        animator.SetTrigger("Die");  
        playerAudio.clip = deathClip;
        playerAudio.Play();

        
        playerRigidbody.velocity = Vector2.zero;
        
        isDead = true;
        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }

        if(other.tag=="Coin")
        {
            GameManager.instance.AddScore(10);

            playerAudio.clip = coinSoundSource;
            playerAudio.Play();
            other.gameObject.SetActive(false);
        }

     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {    
            isGrounded = true;
            jumpCount = 0;
        }
    }
}

