using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Controller : MonoBehaviour
{
    [Header("Movement")]
    private Touch touch;
    private float touchCount;
    public float speedControl = 0.0017f;

    public GameObject tryAgainPanel;


    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {                
                transform.position = new Vector2(transform.position.x + touch.deltaPosition.x * speedControl,
                                        transform.position.y + touch.deltaPosition.y * speedControl);

            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemyBullet"))
        {
            tryAgainPanel.SetActive(true);
        }
    }



}
