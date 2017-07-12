using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	private float speed = 5f;
	private Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = transform.position;
	}

	void OnMouseDown() {
		GM.instance.SetGem (this);
	}

	// Update is called once per frame
	void Update () {
		if (destination == transform.position) {
			CheckForCrush ();
			CheckForEmptySouthThenDrop ();
		}

		CheckForEmptyTopThenSpawn ();
		transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
	}

	void CheckForEmptySouthThenDrop()
	{
		if (transform.position.y > -3f && transform.position.y < 5 && getSouthGem () == null) {
			destination = new Vector3 (transform.position.x, transform.position.y - 2);
		}
	}

	void CheckForEmptyTopThenSpawn ()
	{
		if (transform.position.y == 5 && getSouthGem () == null) {
			GM.instance.placeGem (transform.position.x, transform.position.y - 2);
		}
	}

	private void CheckForCrush() {
		Collider north = getNorthGem ();
		Collider south = getSouthGem ();
		Collider east = getEastGem ();
		Collider west = getWestGem ();

		if (north != null && south != null && north.gameObject.tag == gameObject.tag && south.gameObject.tag == gameObject.tag) {
			Destroy (north.gameObject);
			Destroy (south.gameObject);
			Destroy (gameObject);
			GM.instance.ScorePoints (100);
		}

		if (east != null && west != null && east.gameObject.tag == gameObject.tag && west.gameObject.tag == gameObject.tag) {
			Destroy (east.gameObject);
			Destroy (west.gameObject);
			Destroy (gameObject);
			GM.instance.ScorePoints (100);
		}
	}

	private Collider getNorthGem() {
		return getGem(new Vector3(transform.position.x, transform.position.y + 2));
	}

	private Collider getSouthGem() {
		return getGem(new Vector3(transform.position.x, transform.position.y - 2));
	}

	private Collider getEastGem() {
		return getGem(new Vector3(transform.position.x - 2, transform.position.y));
	}

	private Collider getWestGem() {
		return getGem(new Vector3(transform.position.x + 2, transform.position.y));
	}

	private Collider getGem(Vector3 here) {
		Collider[] gem = Physics.OverlapSphere (here, 0.5f);
		if (gem.Length > 0) {
			return gem [0];
		}
		return null;
	}

	public void SetPosition(Vector3 here) {
		destination = here;
	}
}
