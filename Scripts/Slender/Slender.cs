using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Slender : MonoBehaviour {

	public float speed = 0.5f;
	public float lookTimer = 2f;
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
		
		// Code Not Tested
		if (lookTimer < 0) {
			player.Captured ();
		}
	}
	
	// Code Not Tested
	void OnMouseOver() {
		lookTimer -= Time.deltaTime;
	}

	void JumpToRandomPosition() {
		float x = UnityEngine.Random.Range (100f, 400f);
		float y = 0;
		float z = UnityEngine.Random.Range (100f, 400f);

		transform.position = new Vector3 (x, y, z);
		Invoke ("JumpToRandomPosition", 20f);
	}
}

/*
Slender is 2M tall, has a head, torso, and 2 legs, and 2 eyes that light up.
*/
