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
