using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IGameController{

	public GameObject characterObject;
	private IHealthManager healthManager;

	// Use this for initialization
	void Start () {
		healthManager = characterObject.GetComponent<IHealthManager> ();
		if (healthManager==null) {
			Debug.Log ("Invelid Health Manager Object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void damagePlayer (){
		healthManager.damageOne ();
	}

	public void killPlayer(){
	
	}
	public void respawnPlayer(){
	
	}
}
