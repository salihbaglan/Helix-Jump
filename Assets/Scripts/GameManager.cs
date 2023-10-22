using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelWin;

    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    public static int CurrentLevelIndex;
    public static int noOfPassingRings;

    public Text currentLevelText;
    public Text nextLevelText;

    public Slider proggresBar;

    private void Awake()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start()
    {
        Time.timeScale = 1;
        noOfPassingRings = 0;
        gameOver = false;
        levelWin = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        currentLevelText.text = CurrentLevelIndex.ToString();
        nextLevelText.text = (CurrentLevelIndex + 1).ToString();


        int proggres = noOfPassingRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        proggresBar.value = proggres;

        if (levelWin)
        {
            nextLevelPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", CurrentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }

    public void TimeManagamentStop()
    {
        Time.timeScale = 0;
    }
    public void TimeManagamentPlay()
    {
        Time.timeScale = 1;
    }
}
