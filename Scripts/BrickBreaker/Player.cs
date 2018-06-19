using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 100f;

    private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
            float x = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            x = Mathf.Clamp(x, -4f, 4f);
            transform.position = new Vector3(x, playerPosition.y, playerPosition.z);
        }
}
