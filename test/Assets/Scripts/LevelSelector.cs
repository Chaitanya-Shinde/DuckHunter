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
    //public int level ;
    //public TMP_Text levelText;
    public PlayerInputAsset playerInput;
    public Button[] levelBtns;
    public int levelAt;


    void Start()
    {
        Time.timeScale = 1f;
        playerInput = new PlayerInputAsset();
        //playerInput.LevelSelect.Enable();
        /*playerInput.LevelSelect.Level1.performed += Level1;
        playerInput.LevelSelect.Level2.performed += Level2;
        playerInput.LevelSelect.Level3.performed += Level3;*/
        //levelText.text = level.ToString();

        levelAt = PlayerPrefs.GetInt("levelAt", 2);
        Debug.Log(levelBtns.Length);
        for (int i = 0; i < levelBtns.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                Debug.Log("switched off");
                levelBtns[i].interactable = false;
                //levelBtns[i].GetComponent<OnScreenButton>().enabled = false;

            }
            else
            {
                levelBtns[i].interactable = true;
            }
        }
    }

    private void OnDisable()
    {
        //playerInput.LevelSelect.Disable();

        /*playerInput.LevelSelect.Level1.performed -= Level1;
        playerInput.LevelSelect.Level2.performed -= Level2;
        playerInput.LevelSelect.Level3.performed -= Level3;*/
    }

    /*public void LevelOne()
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(2);

    }*/

    public void Level1(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(2);

    }
    public void Level2(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(3);
        LevelManager.currentLevel = 1;
    }
    public void Level3(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(4);
        LevelManager.currentLevel = 2;
    }public void Level4(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(5);
        LevelManager.currentLevel = 3;
    }public void Level5(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(6);
        LevelManager.currentLevel = 4;
    }public void Level6(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(7);
        LevelManager.currentLevel = 5;
    }public void Level7(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(8);
        LevelManager.currentLevel = 6;
    }public void Level8(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(9);
        LevelManager.currentLevel = 7;
    }public void Level9(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(10);
        LevelManager.currentLevel = 8;
    }public void Level10(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(11);
        LevelManager.currentLevel = 9;
    }public void Level11(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(12);
        LevelManager.currentLevel = 10;
    }public void Level12(/*InputAction.CallbackContext context*/)
    {
        Time.timeScale = 1f;
        //Debug.Log("pressed");
        SceneManager.LoadScene(13);
        LevelManager.currentLevel = 11;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
