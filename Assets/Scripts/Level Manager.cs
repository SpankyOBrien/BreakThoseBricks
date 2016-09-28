﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] bricks;
    public int count = 0;
    private Game_Manager gameManager;
    public string FinishTime;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        Debug.Log("Brick Count: " + bricks.Length);
        count = bricks.Length;
        if (count == 0)
        {
            Debug.Log("All bricks are gone!");
            //Wait before returning to Main level
            StartCoroutine(Pause());
        }
    }
    IEnumerator Pause()
    {
        print("Before Waiting 5 seconds");
        //Switch GameManager State
        gameManager = GameObject.FindObjectOfType<Game_Manager>();
        gameManager.SwitchState(GameState.Completed);
        gameManager.ChangeText("You Win :)");
        FinishTime = gameManager.formattedTime;
        Debug.Log("Took " + FinishTime + " to finish the game");
        yield return new WaitForSeconds(5);

        //Reload Main Menu
        LoadScene(0);
        print("After Waiting 5 Seconds went to main menu");
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}