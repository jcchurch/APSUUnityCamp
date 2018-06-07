# Elements game
This is a game in the style of Candy Crush or Bejeweled.


## Steps
- Create a 2D environment.
- Go to the Asset Store and download a free icon package. I recommend 100 free alchemy icons.
- Create a new Empty Object named “GameManager”.
- Modify this code by adding some variables.

Code.

  	public GameObject generator;
	  public int movesLeft = 15;
	  private Gem first;
	  private int score = 0;

	  public static GameManager instance = null;

- Add the Start.

Code.

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
         
         // Add more later
     		for (int x = -7; x <= 7; x++) {
			    for (int y = -4; y <= 4; y++) {
		    		Instantiate (generator, new Vector3 (x, y, 0), Quaternion.identity);
		    	}
	    	}
    	}

- Add a method to update the score.

Code.

	  public void ScorePoints(int howmany) {
		  score = score + howmany;

		  if (movesLeft <= 0) {
			  Invoke ("Reset", 4f);
		  }
	  }
  
- Pull 5 different sprites into the game.
  - Give them each a different tag.
  - Give them each a **BoxCollider** (make sure it’s not a **BoxCollider2D**).
  - Create a C# Script named Gem.cs, associate the script with each Gem and drop in this code.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Gem : MonoBehaviour {
    	private Vector3 destination;

    	// Use this for initialization
	    void Start () {
		    destination = transform.position;
	    }

    	void OnMouseDown() {
		    GameManager.instance.SetGem (this);
	    }

    	// Update is called once per frame
	    void Update () {
		    if (destination == transform.position) {
			    CheckForCrush ();
		    }

    		transform.position = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * 5);
	    }

      // Skip this.
    	private void CheckForCrush() {
		    float x = transform.position.x;
		    float y = transform.position.y;

    		Collider north = GetGem (x, y + 1);
	    	Collider south = GetGem (x, y - 1);
	    	Collider east = GetGem (x + 1, y);
	    	Collider west = GetGem (x - 1, y);

    		if (north != null && south != null && gameObject.tag == north.tag && gameObject.tag == south.tag) {
		    	Destroy (north.gameObject);
		    	Destroy (south.gameObject);
		    	Destroy (gameObject);
			    GameManager.instance.ScorePoints (100);
		    }
 
    		if (east != null && west != null && gameObject.tag == east.tag && gameObject.tag == west.tag) {
		    	Destroy (east.gameObject);
	    		Destroy (west.gameObject);
			    Destroy (gameObject);
	    		GameManager.instance.ScorePoints (100);
		    }
	    }

      // And this
    	private Collider GetGem(float x, float y) {
		    Vector3 here = new Vector3 (x, y, 0);
		    Collider[] gem = Physics.OverlapSphere (here, 0.25f);
		    if (gem.Length > 0) {
		    	return gem [0];
		    }
    		return null;
	    }

    	public void SetPosition(Vector3 here) {
		    destination = here;
	    }
    }


- Create a function for checking if anything exists below the gem.

Code.

    void CheckForEmptySouthThenDrop()
    {
            if (getSouthGem () == null) {
                    destination = new Vector3 (transform.position.x, transform.position.y - 2);
            }
    }

- Add this function to the Update function, but only call it if we aren’t moving. Also, if we need to move, do so.


Code.

    void Update () {
            if (destination == transform.position) {
                    CheckForEmptySouthThenDrop ();
            }
    
            transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
    }

- Return to **GameManager.cs**. Create a method called `SetGem` which will allow Gems to move.


Code.

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


Code.

    public void OnMouseDown() {
        GameManager.instance.SetGem (this);
    }
    
- Test your game.
- Make a Prefabs folder.
- Move all of your Gems into a Prefabs folder.
- Create a new empty object in your game. This will be a Generator.
  - Name it “Generator”.
  - Dump this code.

Code.
  
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Generator : MonoBehaviour {

    	public Gem red;
    	public Gem black;
    	public Gem green;
    	public Gem blue;
    	public Gem pink;

    	void Start() {
	    	InvokeRepeating ("DropItem", 0, 0.5f);
    	}

    	// Update is called once per frame
	    void Update () {
		
    	}

    	void DropItem() {
		    Vector3 here = new Vector3 (transform.position.x, transform.position.y, 0);
    		Collider[] gem = Physics.OverlapSphere (here, 0.25f);
		    if (gem.Length == 0) {
	    		var gemList = new List<Gem>{ red, black, green, blue, pink };
			    Instantiate(gemList[Random.Range(0,gemList.Count)], here, Quaternion.identity);
	    	}
    	}
    }

I think we are done.
