using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 2f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float y = speed * Time.deltaTime;
		transform.position += new Vector3 (0, y, 0);

		if (transform.position.y > 5)
        {
            Destroy(this.gameObject);
        }
    }

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("Detected Collision from Projectile");
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("Detected Trigger from Projectile");
	}
}
