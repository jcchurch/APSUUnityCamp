using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GM GM;
	public float speed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, -3f, 0);
	}

	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(xPos, -4f, 4f), transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            GM.instance.GainPoints(1);
        }
        else if (other.gameObject.tag == "Potato")
        {
            GM.instance.LoseLife();
        }
    }
}
