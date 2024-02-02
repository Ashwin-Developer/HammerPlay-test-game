using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    public float speedModifier = 1f;

    public int maxHealth = 10;
    private int currenHealth;

    private GameObject player;

    public GameObject obExplosion,playerExplosion,coin;

    public AudioSource obNormAudio;

    public int OBscore = 10;

    //Score score;
    private int scoreToModifySpeed;

    public int sceneID;



    private void Start()
    {
        obNormAudio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        currenHealth = maxHealth;
        scoreToModifySpeed = Score.instance.initialScore;
        Debug.Log(scoreToModifySpeed);
    }
    private void Update()
    {
        //Modifying speed gradually
        /*timer += Time.deltaTime;
        speedModifier = timer;*/

        if (scoreToModifySpeed >= 0 && scoreToModifySpeed < 200)
        {           
            speedModifier = 2f;
        }

        else if(scoreToModifySpeed >= 200 && scoreToModifySpeed < 500)
        {

            speedModifier = 3f;
        }

        else if (scoreToModifySpeed >= 500 && scoreToModifySpeed < 800)
        {
            speedModifier = 4f;
        }

        else if (scoreToModifySpeed >= 800 && scoreToModifySpeed <= 1000)
        {
            speedModifier = 5f;
        }

        transform.Translate(Vector3.down * speedModifier * Time.deltaTime, Space.World);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("OBdestroyer"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            obNormAudio.Play();
            Destroy(gameObject,0.8f);
            Destroy(player);
            Instantiate(playerExplosion, transform.position, Quaternion.identity);

            EndGame.instance.level1(); //ending the level try again .......           
        }

        if (collision.CompareTag("bullet") || collision.CompareTag("leftbullet") || collision.CompareTag("rightbullet"))
        {
            obNormAudio.Play();
        }

    }

    public void takeDamage(int damage)
    {
        

        currenHealth -= damage;
        if (currenHealth <= 0)
        {
            Destroy(gameObject,0.2f);
            Instantiate(obExplosion.gameObject,transform.position, Quaternion.identity);

            Instantiate(coin.gameObject,transform.position, Quaternion.identity);

            sceneID = SceneManager.GetActiveScene().buildIndex;
            
            if (sceneID == 1)
            {
                Score.instance.addScorelvl1(OBscore); //calling score script

            }

            else if (sceneID == 2)
            {
                Score.instance.addScorelvl2(OBscore); //calling score script

            }



        }
    }
}
