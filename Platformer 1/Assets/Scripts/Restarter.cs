﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			ScoreScript.score.reset ();
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else {
			if (other.gameObject.CompareTag("Object")) {
				Destroy (other.gameObject);
			}
		}
	}
}
