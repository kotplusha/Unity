﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void onStart()
	{
		SceneManager.LoadScene ("Test");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}