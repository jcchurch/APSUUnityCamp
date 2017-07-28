# Slender Man

- Download the Standard Assets package.
- Download a Night skybox.
- Download a house package.
- Make the terrain.
- Add trees.
- Add at least one house.
- Change the skybox to night.
- Add the character to the scene.
    - Tag it as Player.
    - Give it a flashlight.
    - Give the flashlight the flashlight cookie.
- Add some variables.

Code.

  	public Text message;
    public int numberOfPages = 8;
    
- Add some code to `Start`.

Code.

    message.text = "Pages remaining: " + numberOfPages;
    
- Create some methods to the Character.

Code.


		void Reset() {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
    
		public void PickUpPage() {
			numberOfPages--;
			message.text = "Pages remaining: " + numberOfPages;

			if (numberOfPages <= 0) {
				message.text = "You escape the slender!";
				Invoke ("Reset", 4f);
			}
		}

		public void Captured() {
			message.text = "Caught!";
			Invoke ("Reset", 4f);
		}
    
- Create a pages. A page is a 1x0.1x1 cube.
- Add a BoxCollider.
- Add a point light to the center of the page.
- Make duplicated the page 7 more times.
- Add some code.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityStandardAssets.Characters.FirstPerson;

    public class Page : MonoBehaviour {

    	public FirstPersonController player;

    	// Use this for initialization
    	void Start () {
		    float x = UnityEngine.Random.Range (100f, 400f);
    		float y = 100;
		    float z = UnityEngine.Random.Range (100f, 400f);

		    transform.position = new Vector3 (x, y, z);
	    }

    	void OnMouseDown() {
		    player.PickUpPage ();
		    Destroy (gameObject);
	    }
    }

- Create Slender.
  - Create a capsul torso. 0.25x0.5x0.25 at 0x1x0
  - Create two legs. Each 0.1x0.4x0.1 at +-0.15x0.4x0
  - Create a head. 0.2x0.4x0.4 at 0x1.7x0
  - Create a point light just above the head.
- Give Slender a Rigidbody.
- Freeze rotation on Slender on the X and Z rotation.
- Add some code.

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityStandardAssets.Characters.FirstPerson;

    public class Slender : MonoBehaviour {

    	public float speed = 1f;
    	public FirstPersonController player;

    	// Use this for initialization
	    void Start () {
		    JumpToRandomPosition ();
	    }
	
    	// Update is called once per frame
	    void Update () {
	    	transform.position = Vector3.MoveTowards (transform.position, player.transform.position,  speed * Time.deltaTime * (8-player.GetNumberOfPages()));

    		if ((transform.position - player.transform.position).magnitude < 5) {
		    	player.Captured ();
		    }
	    }

    	void JumpToRandomPosition() {
		    float x = UnityEngine.Random.Range (100f, 400f);
		    float y = 0;
    		float z = UnityEngine.Random.Range (100f, 400f);

    		transform.position = new Vector3 (x, y, z);
		    Invoke ("JumpToRandomPosition", 20f);
	    }
    }
    
  - Enjoy your game!
