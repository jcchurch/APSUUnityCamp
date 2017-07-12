using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

  public Gem red;
	public Gem black;
	public Gem green;
	public Gem blue;
	public Gem pink;
	public Gem empty;
	public Text message;
	public int movesLeft;

	private Gem first;
	private int score;

	public static GM instance = null;

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

		for (float x = -4; x <= 4; x += 2) {
			Instantiate(empty, new Vector3(x, 5f), Quaternion.identity);
		}

		score = 0;
	}

	public void placeGem(float x, float y)
    {
        int gem = UnityEngine.Random.Range(0, 5);
		Gem toPlace = red;
        if (gem == 1)
        {
            toPlace = black;
        }
        else if (gem == 2)
        {
            toPlace = green;
        }
        else if (gem == 3)
        {
            toPlace = blue;
        }
        else if (gem == 4)
        {
            toPlace = pink;
        }

		Instantiate(toPlace, new Vector3(x, y), Quaternion.identity);
    }

	public void SetGem(Gem gem) {

		if (gem != null && first == null)
		{
			first = gem;
		}
		else if (gem != null && first != null)
		{
			if ((first.transform.position - gem.transform.position).magnitude <= 2f) {
				Vector3 firstLocal = first.transform.position;
				Vector3 secondLocal = gem.transform.position;

				first.SetPosition (secondLocal);
				gem.SetPosition (firstLocal);
				movesLeft--;
				GM.instance.ScorePoints (-50);
			} else {
				print ("Elements are not neighbors.");
			}

			first = null;
		}
	}

	public void ScorePoints(int howmany) {
		score = score + howmany;
		message.text = "Score: " + score + " Moves Left: "+movesLeft;

		if (movesLeft <= 0) {
			message.text = "Game over! Final Score: " + score;
			Invoke ("Reset", 4f);
		}
	}

	private void Reset() {
		SceneManager.LoadScene (0);
	}
}
