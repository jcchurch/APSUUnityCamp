using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject generator;
	public int movesLeft;


	private Gem first;
	private int score;

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

		for (int x = -7; x <= 7; x++) {
			for (int y = -4; y <= 4; y++) {
				Instantiate (generator, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}

	public void SetGem(Gem gem) {

		if (gem != null && first == null)
		{
			first = gem;
		}
		else if (gem != null && first != null)
		{
			Vector3 firstLocal = first.transform.position;
			first.SetPosition(gem.transform.position);
			gem.SetPosition (firstLocal);

			movesLeft--;
			GameManager.instance.ScorePoints (-50);

			first = null;
		}
	}

	public void ScorePoints(int howmany) {
		score = score + howmany;

		if (movesLeft <= 0) {
			Invoke ("Reset", 4f);
		}
	}

	private void Reset() {
		SceneManager.LoadScene (0);
	}
}
