using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
	}
}
