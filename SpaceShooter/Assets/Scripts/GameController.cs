using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;

    public Vector3 spawnValues;

    public int hazardCount;
    public float startWait;
    public float spawnWait;

    private float lastSpawn;
    private float startTime;



    Vector3 spawnPosition;
    Quaternion spawnRotation;
    public GUIText scoreText;
    private int score;

    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOverStatus;
    private bool restartStatus;
    

    public void addToScore(int value)
    {
        score += value;
    }

	// Use this for initialization
	void Start () {
        //spawnWaves();
        score = 0;
        startTime = Time.time;
        lastSpawn = Time.time;
        gameOverStatus = false;
        restartStatus = false;
        restartText.text = "";
        gameOverText.text = "";
	}

    public void gameOver()
    {
        gameOverText.text = "Game Over";
        gameOverStatus = true;
    }


    void upateScore()
    {
        scoreText.text = "Score: " + score;
    }

	// Update is called once per frame
	void Update () {
		
        if(Time.time > startTime + startWait && !gameOverStatus)
        {
            if (Time.time - lastSpawn > spawnWait)
            {
                spawnPosition.Set(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                spawnRotation = Quaternion.identity;
                Instantiate(hazards[Random.Range(0, hazards.Length -1)], spawnPosition, spawnRotation);
                lastSpawn = Time.time;
            }
        }
        upateScore();

        if (gameOverStatus)
        {
            restartText.text = "Press 'R' for Restart";
            restartStatus = true;
        }

        if (restartStatus)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
