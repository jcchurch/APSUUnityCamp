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
