using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class HomeInput : MonoBehaviour
{
    public PlayerInputAsset playerInput;
    

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        playerInput = new PlayerInputAsset();
        
        
        playerInput.UI.Enable();
        //playerInput.Home.Play.performed += LevelSelect;
        playerInput.UI.LevelSelection.performed += LevelSelect;
        playerInput.UI.DeletePrefs.performed += ClearProgress;

    }

    private void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("world");
        SceneManager.LoadScene(1);
    }

    public void Clear()
    {
        Debug.Log("deleted");
        PlayerPrefs.DeleteAll();
    }



    public void ClearProgress(InputAction.CallbackContext context)
    {
        Debug.Log("deleted");
        PlayerPrefs.DeleteAll();
        
    }

    public void LevelSelect(InputAction.CallbackContext context)
    {
        //Debug.Log("hello world");
        SceneManager.LoadScene(1);
    }



    public void NXTLVL()
    {
        //Debug.Log("hello");
        SceneManager.LoadScene(1);
    }


}
