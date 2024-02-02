using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{

    private float speedModifier = 7f;
    public GameObject playerExplosion;
    public AudioSource playerDestruction;

    // Update is called once per frame

    private void Start()
    {
        playerDestruction = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * speedModifier * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject tryAgain = GameObject.FindGameObjectWithTag("tryAgainPanel");
        if (collision.CompareTag("bulletDestroyer"))
        {
            Destroy(gameObject);
        }
        //Obstacle obstacle = collision.GetComponent<Obstacle>();

        if (collision.CompareTag("Player"))
        {
            playerDestruction.Play();
            Destroy(gameObject,0.8f);
            Destroy(player);
            Instantiate(playerExplosion,player.transform.position,Quaternion.identity);
            //target.SetActive(true);
        }

        if (collision.CompareTag("enemyBullletDestroyer"))
        {
            Destroy(gameObject);
        }

    }
}
