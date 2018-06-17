using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 0.5f;
	private float direction = 1;
	private float startx;

	public Player player;
	public GameObject defeated;

    // Use this for initialization
    void Start () {
		startx = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		float y = 0;
		float distance = transform.position.x - startx;

		if (distance > 2) {
			direction = -1;
			y = -1;
		}

		if (distance < -2) {
			direction = 1;
			y = -1;
		}

		float x = speed * Time.deltaTime * direction;
		transform.position += new Vector3 (x, y, 0);

		if (transform.position.y <= -4) {
			defeated.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		player.destoryEnemy ();
		Destroy (collision.gameObject);
		Destroy (gameObject);
	}
}
