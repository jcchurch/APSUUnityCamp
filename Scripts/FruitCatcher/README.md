# Fruit Catcher

- Create the art
  - 800x600 Background
  - 64x64 Glove. Background should be **transparent**.
  - 64x64 Apple. Background should be **transparent**.
  - 64x64 Potato. Background should be **transparent**.
  - 64x64 Rabbit. Background should be **transparent**.
- Throw the art into the scene.
  - Make sure that we discuss Sorting Layers!
  - Make sure that the apple and potato have tags.
  - Go ahead and add a tag to everything just for practice.
- Make the Apple and Potato a **RigidBody2D**.
- Create the Fruit script.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Fruit : MonoBehaviour {
    
            // Use this for initialization
            void Start () {
                    
            }
            
            // Update is called once per frame
            void Update () {
                if (transform.position.y < -4f) {
                    Destroy(gameObject);
                }
            }
    }
- Create the Bunny.
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Bunny : MonoBehaviour
    {
    
        public float speed;
        public GameObject apple;
        public GameObject potato;
    
        private int direction;
    
        // Use this for initialization
        void Start()
        {
            transform.position = new Vector3(0, 4f, 0);
            direction = 1;
            Invoke("dropSomething", 3f);
        }
    
        // Update is called once per frame
        void Update()
        {
            float xPos = transform.position.x + (direction * speed * Time.deltaTime);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    
            if (transform.position.x >= 4f)
            {
                direction = -1;
            }
    
            if (transform.position.x <= -4f)
            {
                direction = 1;
            }
        }
    
        private void dropSomething()
        {
            GameObject toDrop = apple;
            if (UnityEngine.Random.Range(0, 1f) < 0.5)
            {
                toDrop = potato;
            }
    
            Instantiate(toDrop, transform.position, Quaternion.identity);
            Invoke("dropSomething", 3f);
        }
    }
- Put the apple and potato into the Prefabs folder.
- Delete the apple and the potato from the scene.
- Drag the apple and potato into the Script for the Bunny.
- Let’s add the script for the Glove.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Player : MonoBehaviour {
    
            public float speed;
    
            // Use this for initialization
            void Start () {
                    transform.position = new Vector3(0, -3f, 0);
            }
    
            // Update is called once per frame
            void Update () {
                    float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(xPos, -4f, 4f), transform.position.y, transform.position.z);
            }
    }
- Test out the game and play it.
- Time to add the GameManager.

Code.

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    
    public class GameManager : MonoBehaviour {
    
        public GameObject glove;
        public GameObject bunny;
        public Text message;
    
        private int lives;
        private int points;
    
        public static GameManager instance = null;
    
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
            lives = 3;
            points = 0;
            Instantiate(glove);
            Instantiate(bunny);
        }
    
        private void RedrawLabel()
        {
            message.text = "Lives: " + lives + " Score: " + points;
        }
    
        public void GainPoints(int value)
        {
            points += value;
            RedrawLabel();
        }
    
        public void LoseLife()
        {
            lives--;
            RedrawLabel();
            CheckForGameOver();
        }
    
        private void CheckForGameOver()
        {
            if (lives <= 0)
            {
                message.text = "Game Over. Final Score: " + points;
                Invoke("Reset", 3f);
            }
        }
    
        private void Reset()
        {
            SceneManager.LoadScene(0);
        }
    }
    
- Return to the Fruit Script. Modify the update function by adding one line.

Code.

                if (transform.position.y < -4f) {
                    GameManager.instance.LoseLife();
                    Destroy(gameObject);
                }
- Make sure that your glove is a trigger!
- Return to the Glove Script. Add this new method.
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Fruit")
            {
                GameManager.instance.GainPoints(1);
            }
            else if (other.gameObject.tag == "Potato")
            {
                GameManager.instance.LoseLife();
            }
        }
- Play the game.

