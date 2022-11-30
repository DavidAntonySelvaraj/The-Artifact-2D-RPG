using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUiController : MonoBehaviour
{

    public static GameOverUiController Instance;

    [SerializeField]private Canvas gameOverUiCanvas;

    [SerializeField] private Text gameOverUiText;

    [SerializeField] private GameObject enemySpawner;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void GameOver(string gameOverInfo)
    {
        gameOverUiText.text = gameOverInfo;
        gameOverUiCanvas.enabled = true;
        Destroy(enemySpawner);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


























}//class





























