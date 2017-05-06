using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour {
	private bool loadStarted;
	public GameObject restartDialog;
	// Use this for initialization
	void Start () {
		loadStarted = false;
		//restartDialog = GameObject.Find ("GameOver");
		restartDialog.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Finish") && !loadStarted) {
			if (SceneManager.GetActiveScene ().name == "Level1") {
				loadStarted = true;
				SceneManager.LoadScene ("Level2");
			} else {
				restartDialog.SetActive (true);
				restartDialog.GetComponent<GameOverDialogScript>().setPrompt("You Won");
				//ScoreScript.score.reset();
				Time.timeScale = 0;
			}
		}
	}
}
