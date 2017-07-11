using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float initialVelocity;
    private Rigidbody rb;
    private bool inPlay = false;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && inPlay == false)
        {
            transform.parent = null;
            inPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(this.initialVelocity, initialVelocity, 0));
        }

        if (transform.position.y < -4)
        {
            GameManager.instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
