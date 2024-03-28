using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameManager gm;
    private Animator anim;
    private SpriteRenderer sr;
    public float speed;
    public AudioClip coinSound;
    public AudioClip skateSound;
    AudioSource audioSource;
    public AudioSource walkAudioSource;
    public float turboSpeed;
    private float currentSpeed;
    public float playerX; // Declare playerX at class level
    public float playerY; // Declare playerY at class level

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = turboSpeed;
            //sr.color = turboColor;
        }
        else
        {
            currentSpeed = speed;
            //sr.color = Color.white;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentSpeed = 0;
        }
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        
        // Assign playerX and playerY values
        playerX = xMove * currentSpeed * Time.deltaTime;
        playerY = yMove * currentSpeed * Time.deltaTime;

        transform.Translate(playerX, 0, 0); // Move the player
        if (xMove != 0)
        {
            anim.SetBool("Walking", true);
            Debug.Log(walkAudioSource.clip);
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.Play(0);
            }
           
            //audioSource.Pla(skateSound);


            if (xMove < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;   
            }
        }
        else
        {
            anim.SetBool("Walking", false);
            walkAudioSource.Stop();
            //if (audioSource.isPlaying && audioSource.clip == skateSound)
            //{
            //    audioSource.Stop(); // Stop skate sound if player is not walking
            //}
        }   
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("We Collided");
            int tempValue = collision.gameObject.GetComponent<Coin>().value;
            
            
            Destroy(collision.gameObject);
            gm.UpdateScore(tempValue);
            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
                Debug.Log("Coin sound played");
            }
            else
            {
                Debug.Log("Coin sound or AudioSource not assigned!");
            }
        }
        if (collision.gameObject.tag == "hazard")
        {
            Debug.Log("We died");
            Destroy(collision.gameObject); // Call the function to destroy the player
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "themebox")
        {
            Debug.Log("We switch themes");
        }
    }
}