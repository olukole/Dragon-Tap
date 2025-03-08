using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject topObstacle;
    public GameObject bottomObstacle;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;
    public GameObject player;



    public static int score = 0;
    //public int highScore;
    public int reviveCount = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject storeButton;
    public GameObject reviveButton;

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            float waitTime;
            if (score >= 10 && score < 20)
            {
                waitTime = Random.Range(0.5f, 1.5f);
            }
            else if (score >= 20 && score < 30)
            {
                waitTime = Random.Range(0.5f, 1f);
            }
            else if (score > 30)
            {
                waitTime = Random.Range(0.3f, 0.5f);
            }
            else
            {
                waitTime = Random.Range(0.5f, 2f);
            }
            yield return new WaitForSeconds(waitTime);
            Instantiate(topObstacle, topSpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            Instantiate(bottomObstacle, bottomSpawnPoint.position, Quaternion.identity);
        }
    }

    public void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        ScoreUpdate();
    }
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        StartCoroutine(SpawnObstacle());
        score = 0;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
        playButton.SetActive(false);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
        //storeButton.SetActive(true);
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        restartButton.SetActive(false);
        homeButton.SetActive(false);
        //storeButton.SetActive(false);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        GameStart();
    }

    public void GameRevive()
    {
        Time.timeScale = 1;
        player.SetActive(true);
        player.transform.position = new Vector2(0, 1.9f);
        reviveButton.SetActive(false);
        restartButton.SetActive(false);
        homeButton.SetActive(false);
        //storeButton.SetActive(false);
        reviveCount++;

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        if (reviveCount < 3)
        {
            reviveButton.SetActive(true);
        }
        player.SetActive(false);
        restartButton.SetActive(true);
        homeButton.SetActive(true);
        //storeButton.SetActive(true);
    }
}