﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PhysicsPlayer player;
    private bool PlayerAlive;

    public GameObject Canvas;
    public GameObject curCameraPos;
    public GameObject QuitDialog;
    public GameObject PauseDialog;
    public GameObject NextDialog;

    private bool ActiveDialog = false;
    private bool GamePaused = false;
    private bool ActiveNext = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PhysicsPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameStatus();
    }

    private void CheckGameStatus()
    {
        PlayerAlive = player != null;
        if (!PlayerAlive)
        {
            PauseGame();
            Debug.Log(curCameraPos.transform.position);
            QuitDialog.SetActive(true);
            ActiveDialog = true;
        }
        else if (player.transform.position.y < 0)
        {
            PauseGame();
            QuitDialog.transform.position = curCameraPos.transform.position;
            QuitDialog.SetActive(true);
            ActiveDialog = true;
        }
        if (ActiveDialog && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ContinueGame();
            QuitDialog.SetActive(false);
            ActiveDialog = false;

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (Input.GetKey(KeyCode.Tab) && GamePaused == false)
        {
            PauseGame();

            PauseDialog.SetActive(true);
            GamePaused = true;
        }
        if(ActiveNext && Input.GetKeyDown(KeyCode.N))
        {
            ActiveNext = false;
            if(SceneManager.GetActiveScene().name != "Level_2")
            {
                NextStage();
            }
            else
            {
                SceneManager.LoadScene("main_menu_UI");
            }
        }




    }

    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void Continue()
    {

        PauseDialog.SetActive(false);
        GamePaused = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnQuit()
    {
        Application.Quit();
    }

    public void NextDialoga()
    {
        NextDialog.SetActive(true);
        ActiveNext = true;

    }
}
