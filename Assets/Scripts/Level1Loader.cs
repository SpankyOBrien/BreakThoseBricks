﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level1Loader : MonoBehaviour
{
    public GameObject quitButton;
    //Basic function for loading level
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {

        if (Application.isEditor)
        {
            Debug.Log("Attempted to quit from the Editor.");
        }
        else if (Application.isWebPlayer)
        {
            quitButton = GameObject.FindGameObjectWithTag("Quit");
            quitButton.SetActive(false);
            Debug.Log("Attempted to quit from the Web Player.");
        }
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            quitButton = GameObject.FindGameObjectWithTag("Quit");
            quitButton.SetActive(false);
            Debug.Log("Attempted to quit from the WebGL Player.");
        }
        else
        {
            Application.Quit();
        }
    }
}