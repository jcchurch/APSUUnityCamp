using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 100f;

    private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
        playerPosition = new Vector3(0, -3.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        xPosition = Mathf.Clamp(xPosition, -4f, 4f);

        playerPosition = new Vector3(xPosition, playerPosition.y, playerPosition.z);

        transform.position = playerPosition;
    }
}
