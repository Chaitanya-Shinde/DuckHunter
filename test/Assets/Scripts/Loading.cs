using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public int nxtLevel;
    // Start is called before the first frame update
    void Start()
    {
        nxtLevel = LevelManager.nextLevel;
        StartCoroutine(LoadLevel(nxtLevel));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level"+levelIndex);
    }
}
