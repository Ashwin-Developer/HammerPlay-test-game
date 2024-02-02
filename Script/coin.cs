using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public int coinScore = 10;
    private float jumpForce = 5f; 
    Rigidbody2D rb;
    public int sceneID;
    public AudioSource coinSound;

    private void Start()
    {
        coinSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2 (0, jumpForce),ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Score score = collision.GetComponent<Score>();
        if (collision.CompareTag("Player"))
        {

            coinAudio();
            Destroy(gameObject, 0.1f);


            sceneID = SceneManager.GetActiveScene().buildIndex;

            if (sceneID == 1)
            {
                Score.instance.addScorelvl1(coinScore);//calling Score script
            }

            else if (sceneID == 2)
            {
                Score.instance.addScorelvl2(coinScore);//calling Score script
            }

        }

        if (collision.CompareTag("coinDestroyer"))
        {
            Destroy(gameObject);
        }
    }

    private void coinAudio()
    {
        if (coinSound != null)
        {
            Debug.Log("Playing coin sound");
            coinSound.Play();
        }
        else
        {
            Debug.LogWarning("Coin sound is not assigned.");
        }
    }
}
