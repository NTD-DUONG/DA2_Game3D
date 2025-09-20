using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManager instance;
    public bool gameStarted;
    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject menuUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score = 0;
    int highScore;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) {
            if (Input.GetMouseButtonDown(0)) { gameStart(); }
        }
        
    }

    public void gameStart()
    {   gameStarted = true;
        platformSpawner.SetActive(true);
        gamePlayUI.SetActive(true);
        menuUI.SetActive(false);
        StartCoroutine("UpdateScore");
    }
    public void gameOver() {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel",1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }    

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
    }
    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            { PlayerPrefs.SetInt("HighScore", score); }
        }else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }    
    }
}
