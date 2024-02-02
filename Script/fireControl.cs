using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireControl : MonoBehaviour
{
    private Touch touch;
    private float touchCount;

    [Header("Fire")]
    public GameObject fire,leftFire,rightFire;
    public Transform firePosition, rightFirePosition, leftFirePosition;
    //private float speedModifier = 7f;

    public AudioSource shootAudio;
    private float timer = 0f;
    private float interval = 0.3f;

    private void Start()
    {
        shootAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    shootAudio.Play();

                    fireBullet();
                    //reseting the time
                    timer = 0;
                }
            }

        }

    }

    private void fireBullet()
    {
        Instantiate(fire.gameObject, firePosition.transform.position, Quaternion.Euler(0, 0, -90));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("powerUp"))
        {
            powerUp();
        }


    }

    void powerUp()
    {
        float Offset = 3f;

        for (int i = 0; i < 4; i++)
        {

             Instantiate(rightFire, rightFirePosition.position + new Vector3(0f, i * Offset, 0f), Quaternion.Euler(0, 0, -90));
             Instantiate(leftFire, leftFirePosition.position + new Vector3(0f, i * Offset, 0f), Quaternion.Euler(0, 0, -90));

       
        }
        
    }

    

}
