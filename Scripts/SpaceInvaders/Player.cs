using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5f;
	public int enemies = 20;
	public Projectile projectile;
	public GameObject youwin;

	private Projectile fired;

	// Use this for initialization
	void Start () {
		this.fired = null;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.position += new Vector3(x, 0, 0);

		if (Input.GetButton("Fire1") && fired == null)
            fired = Instantiate(projectile, transform.position, transform.rotation);

		if (enemies == 0)
			youwin.SetActive (true);
    }

	public void destoryEnemy() {
		enemies--;
	}
}
