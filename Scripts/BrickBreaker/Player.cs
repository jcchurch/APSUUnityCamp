using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 5f;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		x = Mathf.Clamp (transform.position.x + x, -4.5f, 4.5f);
		transform.position = new Vector3 (x, transform.position.y, 0);
    }
}
