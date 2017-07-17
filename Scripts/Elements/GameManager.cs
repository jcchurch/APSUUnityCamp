using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static GM instance = null;

    // Use this for initialization
    void Start () {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

	}

	private void Reset() {
		SceneManager.LoadScene (0);
	}
}
