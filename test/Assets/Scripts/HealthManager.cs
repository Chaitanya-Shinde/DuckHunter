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
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Color tempColor;
    public Color originalColor;
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

        tempColor = Heart1.color;
        originalColor = Heart1.color;
        tempColor.a = 0f;
        originalColor.a = 1f;
        Heart3.color = originalColor;
        Heart2.color = originalColor;
        Heart1.color = originalColor;
    

    }
    private void Update()
    {
        pointsText = GameObject.Find("Points").GetComponent<TMP_Text>();
        livesText = GameObject.Find("Lives").GetComponent<TMP_Text>();
        Heart1 = GameObject.Find("heart1").GetComponent<Image>();
        Heart2 = GameObject.Find("heart2").GetComponent<Image>();
        Heart3 = GameObject.Find("heart3").GetComponent<Image>();
        //targets = GameObject.FindGameObjectsWithTag("target");
        points = Target.BirdsKilled;
        ManagePoints();
        /*if(LevelManager.playerLost == true)
        {
            currentLives = 0;
        }*/


        switch (currentLives)
        {
            case 2:
                Heart3.color = tempColor;
                break;
            case 1:
                Heart3.color = tempColor;
                Heart2.color = tempColor;
                break;
            case 0:
                Heart3.color = tempColor;
                Heart2.color = tempColor;
                Heart1.color = tempColor;
                break;

        }


        Debug.Log(currentLives);

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
