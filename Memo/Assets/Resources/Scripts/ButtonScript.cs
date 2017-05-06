using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public IGameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<IGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restart()
	{
		gameController.init ();
	}

	public void exit()
	{
		Application.Quit ();
	}
}
