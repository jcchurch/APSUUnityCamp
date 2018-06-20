using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float speed = 1000;

	public int bricks = 12;
	public int lives = 3;
	public Text message;
	public GameObject player;

    private Rigidbody rb;
    private bool inPlay = false;

    // Use this for initialization
    void Start () {
		Reset ();
	}

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void Hit() {
		bricks--;
	}

	void Clear() {
		message.text = "";
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Jump") && inPlay == false)
        {
            transform.parent = null;
            inPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(speed, speed, 0));
        }

        if (transform.position.y < 2)
        {
			lives--;
			Reset ();
        }

		if (lives == 0) 
			message.text = "Game over!";

		if (bricks == 0)
			message.text = "You win!";
    }

	public void Reset() {
		inPlay = false;
		rb.isKinematic = true;
		message.text = "Lives: "+lives;
		Invoke ("Clear", 3f);

		transform.position = new Vector3 (player.transform.position.x, 3, 0);
		transform.SetParent (player.transform);
	}
}
