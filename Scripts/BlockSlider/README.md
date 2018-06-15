## Block Slider Game (3D Game)

## Folders Needed

- Scripts (for all Scripts)
- Materials (for all Material objects)

## Create a GameBoard

- Cube
- Position (0, 0, 0)
- Rotation (0, 0, 0)
- Scale (10x1x10)
- Give it a Green Material

## Move the Camera

- Position (0, 5, -10)
- Rotation (28, 0, 0)
- Scale (1x1x1)

## Create a Goal

- Cube
- Position (4, 1, 0)
- Rotation (0, 0, 0)
- Scale (1x1x1)
- Give it a Pink Material

## Create a Player

- Cube
- Position (-4, 1, 0)
- Rotation (0, 0, 0)
- Scale (1x1x1)
- Give it a Blue Material
- Add a Rigidbody to the Player

## Create a You Win Screen

- UI Text
- Position (0, 0, 0)
- Width: 500
- Height: 200
- Text: "You Win!"
- Color: Yellow
- Font Size: 100
- Once finished: Turn the YouWin UI element off so that it is hidden.

## Add a Script to the Player

Name: Player.cs

    public int speed = 5;

	  // Update is called once per frame
	  void Update () {
		  float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		  float z = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		  transform.position += new Vector3 (x, 0, z);
	  }
    
## Add a Script to the Goal

Name: Goal.cs

You will have to introduce any methods from scratch not named "Start" or "Update".

  	public GameObject message;

  	void OnCollisionEnter(Collision other) {
	  	message.SetActive (true);
	  }

Once this script is created, you'll need to move the "YouWin" UI Text object to the Message field in the Inspector. Play the game to see "You Win!" appear once the goal is reached.
    
## Create an StationaryObstacle

- Cube
- Position (0, 1, 0)
- Rotation (0, 0, 0)
- Scale (1x1x2)
- Give it a Brown Material

 Play the game to see "You Win!" appear once the goal is reached. You will not be able to pass through the StationaryObstacle.

## Create a MovingObstacle.

- Cube
- Position (-1, 1, 0)
- Rotation (0, 0, 0)
- Scale (1x1x2)
- Give it a Yellow Material

## Create a MovingObstacle Script.

Name: MovingObstacle

Notice that this has a public speed and direction variables.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MovingObstacle : MonoBehaviour {

        public int speed = 3;
        public int direction = 1;

        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void Update () {
            float z = direction * speed * Time.deltaTime;
            transform.position += new Vector3 (0, 0, z);

            if (transform.position.z > 4.5)
                direction = -1;

            if (transform.position.z < -4.5)
                direction = 1;
        }
    }


 Play the game to see "You Win!" appear once the goal is reached.
