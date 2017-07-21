using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject glove;
    public GameObject bunny;
    public Text message;

    private int lives;
    private int points;

    public static GameManager instance = null;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Setup();
    }

    private void Setup()
    {
        lives = 3;
        points = 0;
        Instantiate(glove);
        Instantiate(bunny);
    }

    public void GainPoints(int value)
    {
        points += value;
        RedrawLabel();
    }

    private void RedrawLabel()
    {
        message.text = "Lives: " + lives + " Score: " + points;
    }

    public void LoseLife()
    {
        lives--;
        RedrawLabel();
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if (lives <= 0)
        {
            message.text = "Game Over. Final Score: " + points;
            Invoke("Reset", 3f);
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
