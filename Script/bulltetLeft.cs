using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLeft : MonoBehaviour
{
    //public Obstacle obstacle;
    private float speedModifier = 15f;
    public int damage = 10;

    // Update is called once per frame

    void Update()
    {
        float upWeight = 7f;
        Vector3 diagonalDirection = (upWeight * Vector3.up + Vector3.left).normalized;
        transform.Translate(diagonalDirection * speedModifier * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulletDestroyer"))
        {            
            Destroy(gameObject);
        }
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        obMedium obstacleMed = collision.GetComponent<obMedium>();

        if (obstacle != null && collision.CompareTag("obstacleNorm"))
        {
            Destroy(gameObject);
            obstacle.takeDamage(damage);//calling damage in obstacle script 
        }

        if (obstacleMed != null && collision.CompareTag("obstacleMed"))
        {
            Destroy(gameObject);
            obstacleMed.takeDamage(damage);//calling damage in obstacle script 
        }

    }

    
}
