# Breakout Game

Let’s make a breakout game.

## Floor

- Cube
- Position (0, 0, 0)
- Rotation (0, 0, 0)
- Scale (12, 1, 12)
- Add a BoxCollider
- Give it a color.

## Left Wall

- Cube
- Position (-5.5, 5.5, 0)
- Rotation (0, 0, -1)
- Scale (1, 10, 1)
- Add a BoxCollider
- Give it a color.

## Right Wall

- Cube
- Position (5.5, 5.5, 0)
- Rotation (0, 0, -1)
- Scale (1, 10, 1)
- Add a BoxCollider
- Give it a color.

## Ceiling

- Cube
- Position (0, 11, 0)
- Rotation (0, 0, 0)
- Scale (12, 1, 1)
- Add a BoxCollider
- Give it a color.

## Paddle

- Cube
- Position (0, 2, 0)
- Rotation (0, 0, 0)
- Scale (1.5, 1, 1)
- Add a BoxCollider
- Give it a color.

## Bricks

- Cube
- Position (-4, 10, 0)
- Rotation (0, 0, 0)
- Scale (0.5, 0.5, 1)
- Give it a color.

Make several bricks. At least 12. Scatter them around inside of the frame. Make sure the Z position on each is 0. The Z position on everything except for the camera should be 0.

## Ball

- Sphere
- First, make the sphere a child of the Paddle.
- Position (0, 1, 0)
- Rotation (0, 0, 0)
- Scale (1, 1, 1)
- Give it a color.

## Create the Player Script

- Let's program the paddle. Create a script called "Player". It's going to control the paddle.
  - Give it a public variable.

Code.

    public float speed = 5f;
    
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		x = Mathf.Clamp (transform.position.x + x, -4.5f, 4.5f);
		transform.position = new Vector3 (x, transform.position.y, 0);
    }
- Test your code. Make sure the paddle moves back and forth.


## Make a particle system.

Save it to prefabs.

## Make a Brick class.

Make a new Brick class and associate it with each Brick. Make sure that you associate your particle system with each brick too.

	public Ball ball;

	void OnCollisionEnter(Collision other)
    {
		ball.Hit ();
        Instantiate(this.particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

## Time for the Ball Script.

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
