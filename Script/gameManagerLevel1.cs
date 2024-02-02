using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerLevel1 : MonoBehaviour
{
    private int progressAmount = 0;
    public static gameManagerLevel1 instance;
    public Slider progressSlider;
    public GameObject pauseMenu;
    
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


    public void progressScorelvl1(int amount)
    {
        
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if (progressAmount >= 1000) 
        {
            SceneManager.LoadScene(2);
            Debug.Log("lEVEL COMPLETE");//level complete
        }

        /*else if (progressAmount > 100 && progressAmount == 1000)
        {
            Time.timeScale = 0f;
            Debug.Log("lEVEL COMPLETE");//level complete
        }*/

    }

    public void pauseButtonClicked()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void resumeButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
