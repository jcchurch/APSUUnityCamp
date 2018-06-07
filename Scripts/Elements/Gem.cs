using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	private Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = transform.position;
	}

	void OnMouseDown() {
		GameManager.instance.SetGem (this);
	}

	// Update is called once per frame
	void Update () {
		if (destination == transform.position) {
			CheckForCrush ();
		}

		transform.position = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * 5);
	}

	private void CheckForCrush() {
		float x = transform.position.x;
		float y = transform.position.y;

		Collider north = GetGem (x, y + 1);
		Collider south = GetGem (x, y - 1);
		Collider east = GetGem (x + 1, y);
		Collider west = GetGem (x - 1, y);

		if (north != null && south != null && gameObject.tag == north.tag && gameObject.tag == south.tag) {
			Destroy (north.gameObject);
			Destroy (south.gameObject);
			Destroy (gameObject);
			GameManager.instance.ScorePoints (100);
		}

		if (east != null && west != null && gameObject.tag == east.tag && gameObject.tag == west.tag) {
			Destroy (east.gameObject);
			Destroy (west.gameObject);
			Destroy (gameObject);
			GameManager.instance.ScorePoints (100);
		}
	}

	private Collider GetGem(float x, float y) {
		Vector3 here = new Vector3 (x, y, 0);
		Collider[] gem = Physics.OverlapSphere (here, 0.25f);
		if (gem.Length > 0) {
			return gem [0];
		}
		return null;
	}

	public void SetPosition(Vector3 here) {
		destination = here;
	}
}
