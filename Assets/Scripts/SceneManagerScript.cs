using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    int currentSceneIndex = 0;

    internal void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        try
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        
    }

    internal void ReloadLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


}
