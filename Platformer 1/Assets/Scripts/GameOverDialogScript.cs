using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverDialogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.SetActive (false);
		//gameObject.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		Time.timeScale = 1;
		ScoreScript.score.reset ();
		SceneManager.LoadScene ("Level1");
	}
	public void setPrompt(string prompt){
		gameObject.transform.GetChild (1).GetComponent<Text> ().text=prompt;
		
	}
}
