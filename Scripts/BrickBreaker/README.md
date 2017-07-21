# Elements game
This is a game in the style of Candy Crush or Bejeweled.


## Steps
- Create a 2D environment.
- Go to the Asset Store and download a free icon package. I recommend 100 free alchemy icons.
- Create a new Empty Object named “GameManager”.
  - Start the script off with this.
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    
    public class GameManager : MonoBehaviour {
    
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
            }
    
            private void Reset() {
                    SceneManager.LoadScene (0);
            }
    }
- Modify this code by adding some variables.
            public Generator generator;
            public Text message;
            public int movesLeft;
            private int score;
            private Gem first;
- Set score to 0 in the `Start` method.
    score = 0;
- Add a method to update the score.
            public void ScorePoints(int howmany) {
                    score = score + howmany;
                    message.text = "Score: " + score + " Moves Left: "+movesLeft;
    
                    if (movesLeft <= 0) {
                            message.text = "Game over! Final Score: " + score;
                            Invoke ("Reset", 4f);
                    }
            }
- Pull 5 different sprites into the game.
  - Give them each a different tag.
  - Give them each a **BoxCollider** (make sure it’s not a **BoxCollider2D**).
  - Create a C# Script named Gem.cs, associate the script with each Gem and drop in this code.
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Gem : MonoBehaviour {
    
            // Use this for initialization
            void Start () {
            }
    
            // Update is called once per frame
            void Update () {
            }
    
            private Collider getNorthGem() {
                    return getGem(new Vector3(transform.position.x, transform.position.y + 2));
            }
    
            private Collider getSouthGem() {
                    return getGem(new Vector3(transform.position.x, transform.position.y - 2));
            }
    
            private Collider getEastGem() {
                    return getGem(new Vector3(transform.position.x - 2, transform.position.y));
            }
    
            private Collider getWestGem() {
                    return getGem(new Vector3(transform.position.x + 2, transform.position.y));
            }
    
            private Collider getGem(Vector3 here) {
                    Collider[] gem = Physics.OverlapSphere (here, 0.5f);
                    if (gem.Length > 0) {
                            return gem [0];
                    }
                    return null;
            }
    }
- Give each Gem a speed an a destination.
    private float speed = 5f;
    private Vector3 destination;
- Set destination to the the current location.
            void Start () {
                    destination = transform.position;
            }
- Allow the outside world to update the destination.
            public void SetPosition(Vector3 here) {
                    destination = here;
            }
- Create a function for checking if anything exists below the gem.
    void CheckForEmptySouthThenDrop()
            {
                    if (getSouthGem () == null) {
                            destination = new Vector3 (transform.position.x, transform.position.y - 2);
                    }
            }
- Add this function to the Update function, but only call it if we aren’t moving. Also, if we need to move, do so.
    void Update () {
                    if (destination == transform.position) {
                            CheckForEmptySouthThenDrop ();
                    }
    
                    transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
            }
- Return to **GameManager.cs**. Create a method called `SetGem` which will allow Gems to move.
            public void SetGem(Gem gem) {
    
                    if (gem != null && first == null)
                    {
                            first = gem;
                    }
                    else if (gem != null && first != null)
                    {
                            if ((first.transform.position - gem.transform.position).magnitude <= 2f) {
                                    Vector3 firstLocal = first.transform.position;
                                    Vector3 secondLocal = gem.transform.position;
    
                                    first.SetPosition (secondLocal);
                                    gem.SetPosition (firstLocal);
                                    movesLeft--;
                                    score = score - 50;
                            }
    
                            first = null;
                    }
            }
- Return to Gem.cs. Add a new method that allows the user to click on a Gem and call this method.
            public void OnMouseDown() {
                    GameManager.instance.SetGem (this);
            }
- Test your game.
- Make a Prefabs folder.
- Move all of your Gems into a Prefabs folder.
- Create a new empty object in your game. This will be a Generator.
  - Name it “Generator”.
  - Dump this code.
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Generator : MonoBehaviour {
    
            // Update is called once per frame
            void Update () {
            }
    
            private Collider getSouthGem() {
                    return getGem(new Vector3(transform.position.x, transform.position.y - 2));
            }
    
            private Collider getGem(Vector3 here) {
                    Collider[] gem = Physics.OverlapSphere (here, 0.5f);
                    if (gem.Length > 0) {
                            return gem [0];
                    }
                    return null;
            }
    }
- Modify the code to give it some gems to generate.
            public Gem red;
            public Gem black;
            public Gem green;
            public Gem blue;
            public Gem pink;
- Modify Update to look south. If nothing is there, place a gem.
    void Update() {
        if (getSouthGem () == null) {
            float x = transform.position.x;
            float y = transform.position.y - 2;
            var gemList = new List<Gem>{ red, black, green, blue, pink };
            Instantiate(gemList[Random.Range(0,gemList.Count)], new Vector3(x, y), Quaternion.identity);
        }
    }
- Associate your five gems with the Generator.
- Move your Generator into the Prefabs folder.
- Move your Generator from Prefabs into the Generator field in **GameManager**.
- Return to **GameManager.cs**. Add this to the Update method, under the else-if statement in Start method.
    for (float x = -4; x <= 4; x += 2) {
        Instantiate(generator, new Vector3(x, 5f), Quaternion.identity);
    }
- Let’s check for gem crushes. Add this to your **Gem** code.
    private void CheckForCrush() {
                    Collider north = getNorthGem ();
                    Collider south = getSouthGem ();
                    Collider east = getEastGem ();
                    Collider west = getWestGem ();
    
                    if (north != null && south != null && north.gameObject.tag == gameObject.tag && south.gameObject.tag == gameObject.tag) {
                            Destroy (north.gameObject);
                            Destroy (south.gameObject);
                            Destroy (gameObject);
                            GameManager.instance.ScorePoints (100);
                    }
    
                    if (east != null && west != null && east.gameObject.tag == gameObject.tag && west.gameObject.tag == gameObject.tag) {
                            Destroy (east.gameObject);
                            Destroy (west.gameObject);
                            Destroy (gameObject);
                            GameManager.instance.ScorePoints (100);
                    }
            }

I think we are done.
