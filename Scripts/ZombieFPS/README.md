# Zombie FPS

## Download

- The Standard Asset Package.
- Modern Zombie Free
- Sci Fi Gun Heavy

## To do.

- Build a terrain
- Add gun to controller
- Add ZombieRig (color version)
- Add FPSController
- Scale FPSController to 3x3x3
- Add BoxCollider objects to ZombieRig
- Add Skeleton.
- Add BoxCollider objects to ZombieRig
- Create Particle System.
- Create Enemy Script

Code.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Enemy : MonoBehaviour {

    	public ParticleSystem explosion;

    	void OnMouseDown() {
		    Instantiate (explosion, transform.position, Quaternion.identity);
	    	Destroy (gameObject);
    	}
    }
    
## Create the recticle

- Add the GUI recticle icon to the player. Position it just in front of the player.
- Add the sci fi gun.

## Create a waypoint system.

- Create three sphere. They can really be empties, but we can see spheres.
- Drag them to the prefabs.

Code.

  	public ParticleSystem explosion;
    
	  public GameObject first;
	  public GameObject second;
    public GameObject third;

  	public int speed = 5;
	  private Vector3 destination;

  	void Start() {
	  	destination = first.transform.position;
	  }

  	void Update() {
  		if (transform.position == first.transform.position) {
	  		destination = second.transform.position;
		  }

  		if (transform.position == second.transform.position) {
	  		destination = third.transform.position;
		  }
      
      if (transform.position == third.transform.position) {
		  	destination = first.transform.position;
		  }

  		transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
	  }


## The Spawner

Create a new sphere for a spawner.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Spawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 0, 10f);
	}

	void Spawn() {
		Instantiate (enemy, transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		
	}
    }
