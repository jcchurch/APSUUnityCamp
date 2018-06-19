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
- Position (5.5, 5.5, 0)
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
- Position (4, 10, 0)
- Rotation (0, 0, 0)
- Scale (0.5, 0.5, 1)
- Give it a color.

Make several bricks. At least 12. Scatter them around inside of the frame. Make sure the Z position on each is 0. The Z position on everything except for the camera should be 0.

## Ball

- Sphere
- Position (0, 3, 0)
- Rotation (0, 0, 0)
- Scale (1, 1, 1)
- Give it a color.

## Create the Player Script

- Let's program the paddle. Create a script called "Player". It's going to control the paddle.
  - Give it a public variable.

Code.

    public float speed = 100f;
- Set the position of the paddle inside of start.

Code.

    void Start () {
        transform.position = new Vector3(0, -3.5f, 0);
    }
- Update the position based on the keyboard presses. Make sure you spell "Horizontal" correctly.

Code.

    void Update () {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        xPosition = Mathf.Clamp(xPosition, -4.25f, 4.25f);
    
        transform.position = new Vector3(xPosition, playerPosition.y, playerPosition.z);
    }
- Test your code. Make sure the paddle moves back and forth.
- Associate your ball with the paddle. When you move the paddle, the ball should move too.
- Now we need to code the ball to release from the paddle. First, make some private variables.

Code.

    public float initialVelocity = 200f;
    private Rigidbody rb;
    private bool inPlay = false;
- Create a new method called "void Awake()". Associate the Rigidbody with the rb variable.

Code.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
- Update the update method.

Code.

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && inPlay == false)
        {
            transform.parent = null;
            inPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(this.initialVelocity, initialVelocity, 0));
        }
    }
- Play your game. Nothing bounces! Create a new "Physic Material" with full bounce and associate it with everything in your scene (except the floor).
- Create a new Script for the Floor. This one is going to cause the ball to disappear.

Code.

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
       Destroy(other);
    }
- Make a particle system. Save it to prefabs.
- Make a new Brick class and associate it with each Brick. Make sure that you associate your particle system with each brick too.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Brick : MonoBehaviour {
    
        public GameObject particles;
    
            void OnCollisionEnter(Collision other)
        {
            Instantiate(this.particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
- Create a text interface for the number of lives left.
- Create a text interface for “You win!”
- Create a text interface for “You lose!”
- Create an empty object. Create GameManager.cs script for it. Start with this code.

Code.

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    
    public class GameManager : MonoBehaviour {
    
        public static GameManager instance = null;
        private GameObject paddle;
        public GameObject bricksPrefab;
    
        // Use this for initialization
        void Start () {        
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
    
            Setup();
        }
    
        private void Setup()
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
            Instantiate(bricksPrefab, transform.position, Quaternion.identity);
        }
    }
- Make sure that you associate the paddle and the bricks with this script in the empty GameManager that you create.
- Add some variables.

Code.

        public int lives = 3;
        public int bricks = 12;
        public float resetDelay = 1f;
        public Text livesText;
        public GameObject gameOver;
        public GameObject youWon;
        public GameObject bricksPrefab;
        public GameObject paddle;
        public GameObject deathParticles;
- Inside the Setup method, make sure that you create the paddle and the bricks.
- We need lots of little functions.

This resets the scene.

        void Reset()
        {
            SceneManager.LoadScene(0);
        }

This resets just the paddle after each ball loss.

        void SetupPaddle()
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        }

Here’s our GameOver code.

        void CheckGameOver()
        {
            if (bricks <= 0)
            {
                youWon.SetActive(true);
                Invoke("Reset", resetDelay);
            }
    
            if (lives <= 0)
            {
                gameOver.SetActive(true);
                Invoke("Reset", resetDelay);
            }
        }

This needs to be called when we destroy a brick.

        public void DestroyBrick()
        {
            bricks--;
            CheckGameOver();
        }

Here’s our code for the loss of a life.

        public void LoseLife()
        {
            lives--;
            livesText.text = "Lives: " + lives;
            Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
            Destroy(clonePaddle);
            Invoke("SetupPaddle", resetDelay);
            CheckGameOver();
        }
- Now we need to throw code into the game to invoke these new method.
- In the OnCollisionEnter in the Brick class, add this:

Code.

    GameManager.instance.DestroyBrick();
- In the OnCollisionEnter in the Floor class, add this:

Code.

    GameManager.instance.LoseLife();

At this point we should be able to play our game.

