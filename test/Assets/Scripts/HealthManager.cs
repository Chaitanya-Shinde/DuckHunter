using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int startingLives = 2;
    public int startingBullets = 15;
    public static int points =0;
    public TMP_Text livesText;
    public TMP_Text pointsText;
    public static bool playerLost = false;
    //public TMP_Text bulletsText;
    //public GameObject gameOverPanel;

    public static int currentLives;
    private int currentBullets;

    //public GameObject[] targets;
    private void Start()
    {
        currentLives = startingLives;
        currentBullets = startingBullets;

        UpdateLivesText();
        //UpdateBulletsText();
        livesText.text = "Lives: " + currentLives;
        pointsText.text = "Points: " + 0;
    }
    private void Update()
    {
        pointsText = GameObject.Find("Points").GetComponent<TMP_Text>();
        livesText = GameObject.Find("Lives").GetComponent<TMP_Text>();
        //targets = GameObject.FindGameObjectsWithTag("target");
        points = Target.BirdsKilled;
        ManagePoints();
        /*if(LevelManager.playerLost == true)
        {
            currentLives = 0;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            //Debug.Log("Lost a life");
            ReduceLives();
        }
    }

    public void ManagePoints()
    {
        pointsText.text = "Points: " + points;
    }
    public void ReduceLives()
    {
        currentLives--;

        if (currentLives == 0)
        {
            GameOver();
            playerLost = true;
            
        }
        else if(currentLives !=0 && currentLives>0)
        {
            playerLost = false;
            //Debug.Log("lost a heart");
            UpdateLivesText();
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives;
        //Debug.Log(currentLives);
    }

   /* private void UpdateBulletsText()
    {
        bulletsText.text = "Bullets: " + currentBullets.ToString();
    }*/

    private void GameOver()
    {
        Debug.Log("Game over");
        livesText.text = "Lives: 0";
        //gameOverPanel.SetActive(true);
        // Add any additional game over logic here
    }
}
