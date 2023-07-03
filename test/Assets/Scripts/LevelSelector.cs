using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public PlayerInputAsset playerInput;
    public Button[] levelBtns;
    public int levelAt;


    void Start()
    {
        Time.timeScale = 1f;
        playerInput = new PlayerInputAsset();
        levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelBtns.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                Debug.Log("switched off");
                levelBtns[i].interactable = false;
            }
            else
            {
                levelBtns[i].interactable = true;
            }
        }
    }


    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);

    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
        LevelManager.currentLevel = 1;
    }
    public void Level3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
        LevelManager.currentLevel = 2;
    }
    public void Level4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
        LevelManager.currentLevel = 3;
    }
    public void Level5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(6);
        LevelManager.currentLevel = 4;
    }
    public void Level6()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(7);
        LevelManager.currentLevel = 5;
    }
    public void Level7()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(8);
        LevelManager.currentLevel = 6;
    }
    public void Level8()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(9);
        LevelManager.currentLevel = 7;
    }
    public void Level9()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(10);
        LevelManager.currentLevel = 8;
    }
    public void Level10()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(11);
        LevelManager.currentLevel = 9;
    }
    public void Level11()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(12);
        LevelManager.currentLevel = 10;
    
    }public void Level12()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(13);
        LevelManager.currentLevel = 11;
    }


}
