# Space Invaders (2D Game)

## Folders Needed

- Animations
- Prefabs
- Scripts

## Download Assets

- Download the Galaxia 2D Space Shooter Sprite Pack #1

## Create a YouWin screen.

- Text UI GameObject
- Position (0, 0, 0)
- Width 500
- Height 500
- Font Size 100
- Paragraph Alignment: Horizontal Center, Vertical Center
- Text: "You win!"
- Name the Canvas "YouWin"

## Create a Defeated screen

- Copy the "YouWin" Canvas. This way we keep all of our customizations.
- Change the Text: "Defeated!":
- Change the Canvas name from "YouWin (1)" to "Defeated".

## Turn off all Canvases.

- Turn off the checkbox beside YouWin canvas by the name in the inspector.
- Turn off the checkbox beside Defeated canvas by the name in the inspector.

## Create the Player

- Sprite: idle_player_upgrade2
- Position (0, -4, 0)
- Rotation (0, 0, 0)
- Scale (2x2x1)

## Create the Projectile

- Find the image "BulletBombSpriteSheetBlue.png" in the Sprite pack's Effects folder and drag it to the Scene area.
    - You should be asked to save an animation. Save it to the Anaimations folder as "Projectile".
- Rename the sprite "Projectile".
- Give it a BoxCollider2D.
- Save the GameObject in the Prefabs folder.
- Delete the Projectile that you created in the Scene view. Don't worry. It should be saved in Prefabs.

## Create a Projectile sciprt.

Add a Script component to the Projectile prefab.

Name: Projectile.cs

    public float speed = 4f;

    // Update is called once per frame
	 void Update () {
         float y = speed * Time.deltaTime;
	    	transform.position += new Vector3 (0, y, 0);

	    	if (transform.position.y > 5)
            Destroy(this.gameObject);
    }
    
 ## Create a Player sciprt.

Add a Script component to the Player object.

Name: Player.cs

		using System.Collections;
		using System.Collections.Generic;
		using UnityEngine;

		public class Player : MonoBehaviour {

		  public float speed = 5f;
			public int enemies = 20;
			public Projectile projectile;
			public GameObject youwin;

			private Projectile fired;

			// Use this for initialization
			void Start () {
				this.fired = null;
			}
			
			// Update is called once per frame
			void Update () {
		        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
				transform.position += new Vector3(x, 0, 0);

				if (Input.GetButton("Fire1") && fired == null)
		            fired = Instantiate(projectile, transform.position, transform.rotation);

				if (enemies == 0)
					youwin.SetActive (true);
		    }

			public void destoryEnemy() {
				enemies--;
			}
		}

After completing the script, assign the Projectile prefab to the Player's Projectile field and the YouWin canvas to the Youwin field.

Play the game. The ship should fire projectiles.

## Add an Enemy to hit.

- Find the Enemy folder in the Galaxia Sprite Package. Pick an enemy and drag it to the scene.
- Position (-4, 4, 0)
- Rotation (0, 0, 180) This way it points downward.
- Scale (2x2x1)
- Give the Enemy a BoxCollider2D.
- Check the box to make the BoxCollider2D a Is Trigger.
- Give the Enemy a Rigidbody2D.
- Make the Body Type "Kinematic".

## Add an Enemy Script

Name: Enemy.cs

Most of this code defines the zigzag nature of the ships. It will also disappear upon being hit with a projectile.

		using System.Collections;
		using System.Collections.Generic;
		using UnityEngine;

		public class Enemy : MonoBehaviour {

			public float speed = 0.5f;
			private float direction = 1;
			private float startx;

			public Player player;
			public GameObject defeated;

		    // Use this for initialization
		    void Start () {
				startx = transform.position.x;
			}
			
			// Update is called once per frame
			void Update () {

				float y = 0;
				float distance = transform.position.x - startx;

				if (distance > 2) {
					direction = -1;
					y = -1;
				}

				if (distance < -2) {
					direction = 1;
					y = -1;
				}

				float x = speed * Time.deltaTime * direction;
				transform.position += new Vector3 (x, y, 0);

				if (transform.position.y <= -4) {
					defeated.SetActive (true);
				}
			}

			void OnTriggerEnter2D(Collider2D collision) {
				player.destoryEnemy ();
				Destroy (collision.gameObject);
				Destroy (gameObject);
			}
		}
    
After competing this script, drag the Player game object to the Enemy's player field and the Defeated canvas to the Defeated field.

## Make more enemies: TWO

- Copy and paste your first enemy.
- Position (-4, 3, 0)
- Give it a new enemy sprite.

## Make more enemies: THREE

- Copy your first enemy.
- Position (-4, 2, 0)
- Give it a new enemy sprite.


## Make more enemies: FOUR

- Copy and paste your first enemy.
- Position (-4, 1, 0)
- Give it a new enemy sprite.

At this point, you should have four enemies on the screen.

## Make more enemies: Column 2

- Select all of your first column of enemies and copy and paste it.
- Set the X position on the new group of four enemies to be -2.

## Make more enemies: Column 3

- Select all of your first column of enemies and copy and paste it.
- Set the X position on the new group of four enemies to be 0.

## Make more enemies: Column 4

- Select all of your first column of enemies and copy and paste it.
- Set the X position on the new group of four enemies to be 2.

## Make more enemies: Column 5

- Select all of your first column of enemies and copy and paste it.
- Set the X position on the new group of four enemies to be 4.

At this point there should be 20 enemies on the screen. Play the game.
