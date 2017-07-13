using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {

	public Material onMaterial;
	public Material offMaterial;

	public Toggle a;
	public Toggle b;
	public Toggle c;
	public Toggle d;

	private bool on;

	// Use this for initialization
	void Start () {
		on = false;
		if (UnityEngine.Random.Range (0.0f, 1.0f) < 0.5) {
			on = true;

		}
	}

	void OnMouseDown() {
		Flip ();
		if (a != null) a.Flip ();
		if (b != null) b.Flip ();
		if (c != null) c.Flip ();
		if (d != null) d.Flip ();
	}

	public void Flip() {
		on = !on;
	}
	
	// Update is called once per frame
	void Update () {
		if (on) {
			GetComponent<Renderer> ().material = onMaterial;
		} else {
			GetComponent<Renderer> ().material = offMaterial;
		}
	}
}
