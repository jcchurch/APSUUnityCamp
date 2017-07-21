using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public Gem red;
        public Gem black;
        public Gem green;
        public Gem blue;
        public Gem pink;
	
	// Update is called once per frame
	void Update () {
            if (getSouthGem () == null) {
                float x = transform.position.x;
                float y = transform.position.y - 2;
                var gemList = new List<Gem>{ red, black, green, blue, pink };
                Instantiate(gemList[Random.Range(0,gemList.Count)], new Vector3(x, y), Quaternion.identity);
            }
	}

	private Collider getSouthGem() {
		return getGem(new Vector3(transform.position.x, transform.position.y - 2));
	}

	private Collider getGem(Vector3 here) {
		Collider[] gem = Physics.OverlapSphere (here, 0.5f);
		if (gem.Length > 0) {
			return gem [0];
		}
		return null;
	}
}
