using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject hazard;
    [SerializeField] private int spawnCount;
    [SerializeField] private float spawnWait;
    [SerializeField] private float startSpawn;
    [SerializeField] private float waveWait;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text exitText;
    [SerializeField] private int score;

    private bool restart;
    private bool gameOver;

    void Update()
    {
        if(restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);

        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
                if (gameOver == true)
                {
                    restartText.text = "Press 'R' for Restart";
                    exitText.text = "Press 'Q' for Quit";
                    restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void ScoreUpdate()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Start()
    {
        gameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
    }
}
