using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour,IHealthManager{

	public GameObject[] hearts;
	public GameObject gameControllerObject;

	private int health;
	private IGameController gameController;

	public Rigidbody2D characterBody;
	public Platformer2DUserControl playerControl;

	public  GameObject restartDialog;

	// Use this for initialization
	void Start () {
		reset ();
		gameController = gameControllerObject.GetComponent<IGameController> ();
		if(gameController==null)
			Debug.Log("Invalid Game Controller Object");
		//restartDialog = GameObject.Find ("GameOver");
		restartDialog.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Trap")) {
			damageOne ();
			StartCoroutine(haltMove());
			characterBody.velocity = (gameObject.transform.position - other.gameObject.transform.position).normalized * 20;
		}
	}

	IEnumerator haltMove(){
		playerControl.controllerEnabled = false;
		yield return new WaitForSeconds(0.5f);
		playerControl.controllerEnabled = true;

	}


	public void reset (){
		health = hearts.Length;
		for (int i = 0; i < hearts.Length; i++) {
			hearts [i].SetActive (true);
		}
	}

	public void addOne (){
		if (health<3) {
			hearts [health].SetActive (true);
			health++;
		}
	}

	public void damageOne (){
		health--;
		Debug.Log (health);
		hearts [health].SetActive (false);
		if (health == 0) {
			restartDialog.GetComponent<GameOverDialogScript> ().setPrompt ("Game Over");
			restartDialog.SetActive (true);
			Time.timeScale = 0;
		}
		
	}

	public int getHealth()
	{
		return health;
	}
		
}
