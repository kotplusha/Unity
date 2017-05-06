using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {
	private IGameController gameController;
	private int id;
	private bool hidden;
	public Sprite face;
	private Sprite back;
	private bool guessed;


	// Use this for initialization
	void Start () {
		gameController=GameObject.FindGameObjectWithTag("GameController").GetComponent<IGameController>();
		back=Resources.Load<Sprite>("Sprites/back");
		Hidden = true;
		guessed = false;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int Id{
		get{ return id;}
		set
		{
			id = value;
			gameObject.GetComponentInChildren<Text> ().text ="";

			face = Resources.Load<Sprite>("Sprites/s"+id);
			//gameObject.GetComponent<Button> ().image.sprite = face;
		}
	}

	public void onClick()
	{
		if (!guessed && gameController.canClick ()) {
			Hidden = !Hidden;
			gameController.clicked (this);
		}
	}

	public bool Hidden{
		get{
			return hidden;
		}
		set{
			hidden = value;
			//gameObject.GetComponentInChildren<Text> ().text = (hidden ? "" : ("" + id));
			gameObject.GetComponent<Image>().sprite = hidden ? back : face;
		}
	}
	public void freeze()
	{
		guessed = true;
	}
}
