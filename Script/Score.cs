using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI scoreText;
    public int initialScore = 0;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void addScorelvl1(int score)
    {

        initialScore += score;
        scoreText.text = "" + initialScore;

        gameManagerLevel1.instance.progressScorelvl1(score);
        
    }

    public void addScorelvl2(int score)
    {

        initialScore += score;
        scoreText.text = "" + initialScore;

        gameManagerLevel2.instance.progressScorelvl2(score);

    }


}
