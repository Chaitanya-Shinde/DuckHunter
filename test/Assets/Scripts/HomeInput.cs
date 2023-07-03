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

    private void Start()
    {
        playerInput = new PlayerInputAsset();
        playerInput.UI.Enable();
        playerInput.UI.LevelSelection.performed += LevelSelect;
        playerInput.UI.DeletePrefs.performed += ClearProgress;
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

        SceneManager.LoadScene(1);
    }

    public void NXTLVL()
    {
        SceneManager.LoadScene(1);
    }


}
