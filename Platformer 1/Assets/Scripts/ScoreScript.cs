using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {
	private int _score=0;
	public static ScoreScript score;

	// Use this for initialization
	void Awake() {
		if (score == null) {
			DontDestroyOnLoad (gameObject);
			score = this;
		} else if (score != this){
			Destroy (gameObject);
			
		}



		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void addOne(){
		_score++;
	}

	public int getScore(){
		return _score;
	}

	public void reset(){
		_score = 0;
	}
}
