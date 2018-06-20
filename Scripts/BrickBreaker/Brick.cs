using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject particles;
	public Ball ball;

	void OnCollisionEnter(Collision other)
    {
		ball.Hit ();
        Instantiate(this.particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
