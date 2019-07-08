# Canyon Flight Game (2D Game)

## Creation Video

- [Canyon Flight on YouTube](https://www.youtube.com/watch?v=av6p5TOmhII)

## Folders Needed

- Scripts (for all Scripts)
- Prefabs (for all Prefab objects)

## Pull a ship from the Asset Store

- Click on the "Asset Store" tab.
- Filter the price to "Free".
- Make sure that you request a 2D asset.
- Search for "spaceship".
- Find a ship with an overhead view (like in the video)

## Pull the ship into the Scene view

- The ship exists in the "2D Pixel Spaceship - Two Small Ships > Prefabs > ships" folder. Select a ship.
- Position: (0, -4, 0)
- The ship needs to be rotated to face up. Set the rotation to (0, 0, 180)
- The scale is unchanged at (1, 1, 1)
- Rename the ship to "Ship".

## Add components to the Ship

- Add Component "Box Collider 2D".
    - Make sure that you select that this is "Is Trigger".
- Add Component "Rigidbody 2D".
    - Make sure that you set the Body Type to "Kinematic". It is originally set to "Dynamic".

## Create a new Script for Ship named "Ship.cs".

Move this script to the "Scripts" folder.

Add code to the file:

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Ship : MonoBehavior
    {
         public float speed = 5.0f;

         // Start is called before the first frame update
         void Start()
         {

         }

         // Update is called once per frame
         void Update()
         {
             float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
             transform.position += new Vector3(x, 0, 0);
         }
    }

At this point, playing your game should cause the ship to move left and right using the arrow keys or using "A" and "D".

## Getting the Score to Appear

- Create a UI Text Element
    - Right click in the Hierarchy. Select "UI", then "Text".

## Move the text to the upper-left corner.

- Select the Text in the Hierarchy.
- Select the Rect Transform Bull's Eye.
- With the Anchor Presets window visible, hold the "ALT" key and select the "top-left" corner. The text should move the upper-left corner.
- While we are here, change the font size to 20.
- Change the color to Black.

## Add support for the UI Text element in the Ship.cs script

Add a new "using" statement. This will go under "using UnityEngine;".

    using UnityEngine.UI;

In the public variables area, create a variable using Text. Notice: Text is capitalized.

    public Text message;

In the Update method, add this line at the bottom:

    message.text = "Score: " + Time.frameCount;

In Unity, find the variable **Message** in the Ship's Inspector. Drag the **Text** object in the Hierarchy to the **Message** variable.

Play the game. The score should increase.

## Create part of a Canyon Edge

- Enter the prefabs folder.
- Right click in the empty folder, and select "Create > Sprites > Square".
- Name the Square "Square".
- Drag the Square to the Scene view.

## Modify the Square.

- Position: doesn't matter
- Rotation: (0, 0, 0)
- Scale: (10, 1, 1)
- Add Component "Box Collider 2D".
- Name your Square "Canyon".

## Add a script to the Canyon object named "Canyon.cs".

Move this script to the "Scripts" folder.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Canyon : MonoBehavior
    {
         public float speed = 2.5f;

         // Start is called before the first frame update
         void Start()
         {

         }

         // Update is called once per frame
         void Update()
         {
             float y = -1 * speed * Time.deltaTime;
             transform.position += new Vector3(0, y, 0);

             if (transform.position.y < -6) {
                 Destroy(gameObject);
             }
         }
    }

Run the game and the Canyon piece should move towards the bottom of the screen.

## Create the Canyon Manager

- Begin by dragging the Canyon object to the prefabs folder.
- Only after the previous step is done, delete the Canyon object in the Hierarchy. Messing this up will cause the student to recreate the Canyon object from scratch.
- Create an Empty object by right clicking in the Hierarchy and selecting "Create Empty".
- Rename the empty GameObject to CanyonManager.

## Add a script to the CanyonManager object named "CanyonManager.cs".

Move this script to the "Scripts" folder.

Let's begin with Start method.

     public GameObject canyon;
     public float gap = 14.0f;
     public float center = 0.0f;
     public int canyonEdgeCount = 0;

     // Start is called before the first frame update
     void Start()
     {
         for (float y = -4; y < 6; y++) {
             Instantiate(canyon, new Vector3(center - (gap / 2), y, 1), Quaternion.identity, transform);
             Instantiate(canyon, new Vector3(center + (gap / 2), y, 1), Quaternion.identity, transform);

             canyonEdgeCount += 2;
         }
     }

Run the game. There should be 20 canyon pieces on the screen, all crawling towards the bottom of the screen. The `canyonEdgeCount` variable keeps track of the initial number of canyon edge pieces.

## Word on the Update method

Code.

    // Update is called once per frame
    void Update()
    {
        if (canyonEdgeCount - transform.childCount >= 2) {
            gap = Mathf.Cos(Time.frameCount / 60.0f) + 16.0f;
            center = 5.0f * Mathf.Sin(Time.frameCount / 240.0f);
            Instantiate(canyon, new Vector3(center - (gap / 2), 4, 1), Quaternion.identity, transform);
            Instantiate(canyon, new Vector3(center + (gap / 2), 4, 1), Quaternion.identity, transform);
        }
    }

## Return to the Ship script.

We need to make the Ship be destroyed when it collides with a wall.

     void OnTriggerEnter2D() {
         Destroy(gameObject);
     }

