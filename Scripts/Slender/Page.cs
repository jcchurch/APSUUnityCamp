using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Page : MonoBehaviour {

	public FirstPersonController player;

	// Use this for initialization
	void Start () {
		float x = UnityEngine.Random.Range (100f, 400f);
		float y = 0;
		float z = UnityEngine.Random.Range (100f, 400f);

		transform.position = new Vector3 (x, y, z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		player.PickUpPage ();
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			player.PickUpPage ();
			Destroy (gameObject);
		}
	}
}

/*
Page is a rigidbody with a box collider. 1x0.1x1
*/
