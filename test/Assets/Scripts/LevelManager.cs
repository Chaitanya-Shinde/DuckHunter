using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public PlayerInputAsset playerInput;
    public static LevelManager Instance;
    public string[] levelScenes;  // Array of scene names for the levels

    public static int currentLevel=0; // Current level index
    public int crntLVL;
    public static int nextLevel;
    public int nextSceneLoad = 0;
    //public GameObject PauseMenu;
    public CanvasGroup pauseCG;
    public CanvasGroup nxtLevelCG;
    public CanvasGroup youLoseCG;
    public TMP_Text lvlText;
    public TMP_Text goalText;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(base.gameObject);
        }
    }

    /*private void OnEnable()
    {
        
        Time.timeScale = 1f;
        playerInput.Player.Enable();
        playerInput.Player.Pause.performed += PauseGame;
        playerInput.Player.Resume.performed += ResumeGame;
        playerInput.Player.MainMenu.performed += MainMenu;
        playerInput.Player.NextLevel.performed += LoadNextLevel;
        //HealthManager.playerLost = false;
    }*/
    void Start()
    {
        
        playerInput = new PlayerInputAsset();
        //playerInput.Home.Enable();
        playerInput.Player.Enable();
        playerInput.Player.Pause.performed += PauseGame;
        playerInput.Player.Resume.performed += ResumeGame;
        playerInput.Player.MainMenu.performed += MainMenu;
        playerInput.Player.NextLevel.performed += LoadNextLevel;
        //playerInput.UI.DeletePrefs.performed += DeletePlayerPrefs;

        
        //LoadLevel(currentLevel);
    }

    private void Update()
    {
        lvlText = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        goalText = GameObject.Find("GoalText").GetComponent<TMP_Text>();
        pauseCG = GameObject.Find("PauseMenu").GetComponent<CanvasGroup>();
        nxtLevelCG = GameObject.Find("NextLevelScreen").GetComponent<CanvasGroup>();
        youLoseCG = GameObject.Find("YouLoseScreen").GetComponent<CanvasGroup>();
        crntLVL = currentLevel + 1;
        lvlText.text = "Level: " + crntLVL;

        DifficultyHandler();
        //PlayerLost();

        //Debug.Log(currentLevel);

        Debug.Log(PlayerPrefs.GetInt("levelAt"));

        if (HealthManager.playerLost)
        {
            PlayerLost();
        }

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            Debug.Log("You win!!!");
        }
        else if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }

       /* if(playerInput.Player.enabled == true)
        {
            Debug.Log("Player input actiosn is enabled");
        }
        if(playerInput.UI.enabled == true)
        {
            Debug.Log("UI input actiosn is enabled");
        }
        */

        
    }

    /*void DeletePlayerPrefs(InputAction.CallbackContext context)
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("deleted prefs");
    }*/

    void PauseGame(InputAction.CallbackContext context)
    {
        Time.timeScale = 0f;
        Debug.Log("game paused");
        pauseCG.alpha = 1f;
        pauseCG.blocksRaycasts = true;
        pauseCG.interactable = true;
    }

    void ResumeGame(InputAction.CallbackContext context)
    {
        Time.timeScale = 1f;
        Debug.Log("game resumed");
        pauseCG.alpha = 0.0f;
        pauseCG.blocksRaycasts = false;
        pauseCG.interactable = false;
    }

    void MainMenu(InputAction.CallbackContext context)
    {
        HealthManager.playerLost = false;
        currentLevel = 0;
        Debug.Log("Main Menu");
        pauseCG.alpha = 0.0f;
        pauseCG.blocksRaycasts = false;
        HideNextLevelMenu();
        //HideYouLoseScreen();
        //LoadLevel(0);
        HideYouLoseScreen();
        SceneManager.LoadScene(0);
        //StartCoroutine(Delay());
        HealthManager.currentLives = 0;
        ResetAllData();
        Time.timeScale = 1f;


    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
    }

    public void LoadLevel(int levelIndex)
    {
        Time.timeScale = 1f;
        HideYouLoseScreen();
        //StartCoroutine(Delay());
        // Check if the level index is within the bounds of the level scenes array
        if (levelIndex >= 0 && levelIndex < levelScenes.Length)
        {
            // Load the specified scene
            HideNextLevelMenu();
            
            ResetAllData();
            Time.timeScale = 1f;
            SceneManager.LoadScene(levelScenes[levelIndex+1]);
            currentLevel++;
            //currentLevel = levelIndex;
            
        }
        else
        {
            // Level index is out of bounds
            Debug.LogError("Invalid level index: " + levelIndex);
        }
    }

    public void LoadNextLevel(InputAction.CallbackContext context)
    {
        HideNextLevelMenu();
        HideYouLoseScreen();
        Time.timeScale = 1f;
        HealthManager.currentLives = 0;
        int nextLevelIndex = currentLevel + 1;
        nextLevel = nextLevelIndex;

        // Check if the next level index is within the bounds of the level scenes array
        if (nextLevelIndex < levelScenes.Length)
        {
            
            
            ResetAllData();
            Debug.Log("Level Complete");
            Time.timeScale = 1f;
            //SceneManager.LoadScene("Loading");
            
            LoadLevel(nextLevelIndex);
            

        }
        else
        {
            // All levels have been completed
            Debug.Log("All levels completed!");
        }
        
    }

    void ResetAllData()
    {
        //currentLevel = 0;
        Time.timeScale = 1f;
        
        Target.BirdsKilled = 0;
        //Debug.Log("reset all Data");
    }

    public void DifficultyHandler()
    {
        if(crntLVL ==1)
        {
            goalText.text = "Score 1 point!";
            
            //Destroy(goalText.gameObject,2);
            
            if(Target.BirdsKilled >0)
            {
                //Time.timeScale = 0f;
                //Debug.Log("level complete");
                ShowNextLevelMenu();
            }
            
            //Invoke("HideGoalText", 2);
            StartCoroutine(HideGoalText());

        }
        else if(crntLVL >=2 && crntLVL <5)
        {
            goalText.text = "Score 3 points!";
            //goalText.alpha = 0f;
            //Destroy(goalText.gameObject, 2);
            
            if (Target.BirdsKilled > 2)
            {
                //Time.timeScale = 0f;
                Debug.Log("level complete");
                ShowNextLevelMenu();
            }
            //Invoke("HideGoalText", 2);
            StartCoroutine(HideGoalText());

        }
        else if (crntLVL >=5 && crntLVL < 13)
        {
            goalText.text = "Score 5 points!";
            //Destroy(goalText.gameObject, 2);
            
            
            if (Target.BirdsKilled > 4 && crntLVL != 12)
            {
                //Time.timeScale = 0f;
                Debug.Log("level complete");
                ShowNextLevelMenu();
            }
            else if(Target.BirdsKilled >4 && crntLVL == 12)
            {
                SceneManager.LoadScene(14);
            }
            //Invoke("HideGoalText", 2);
            StartCoroutine(HideGoalText());
            
            
            
        }

    }

    IEnumerator HideGoalText()
    {
        yield return new WaitForSeconds(2);
        //goalText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        goalText.alpha = 0f;
    }

    void PlayerLost()
    {
        //if(HealthManager.currentLives == 0)
        //{
            //Time.timeScale = 0f;
            //StartCoroutine(Delay());
            currentLevel = 0;
            ShowYouLoseScreen();
            //playerLost = false;
        //}
    }

    void ShowNextLevelMenu()
    {
        //Time.timeScale = 0f;
        nxtLevelCG.alpha = 1.0f;
        nxtLevelCG.blocksRaycasts = true;
        nxtLevelCG.interactable = true;
    }

    void HideNextLevelMenu()
    {
        Time.timeScale = 1f;
        nxtLevelCG.alpha = 0.0f;
        nxtLevelCG.blocksRaycasts = false;
        nxtLevelCG.interactable = false;
    }

    void ShowYouLoseScreen()
    {
        //yield return new WaitForSeconds(2);
        //Time.timeScale = 0f;
        //HealthManager.currentLives = 0;
        youLoseCG.alpha = 1.0f;
        youLoseCG.blocksRaycasts = true;
        youLoseCG.interactable = true;
    }

    void HideYouLoseScreen()
    {
        Time.timeScale = 1f;
        youLoseCG.alpha = 0.0f;
        youLoseCG.blocksRaycasts = false;
        youLoseCG.interactable = false;
    }

}
