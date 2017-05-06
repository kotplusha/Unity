using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour, IGameController{

	public const float MARGIN_RATE = 0.01f;
	public const float HIDE_DELAY = 1.0f;
	private const float CARD_RATE = 0.24f;
	private Text scoreText; 
	private GameObject restart;
	private int score;
	private float minDim;
	private CardScript fCard=null;
	private CardScript sCard=null;
	private GameObject cardPF;
	private int toGuess;
	private Vector2 canvasDim;
	GameObject[] cards;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("Score").GetComponentInChildren<Text>();

		cardPF = Resources.Load ("Prefabs/PFCard") as GameObject;

		restart = GameObject.Find ("Restart");

		init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		if (cards != null) {
			for (int i = 0; i < 16; i++) {
				Destroy (cards [i]);
			}
		}
		score = 0;
		scoreText.text = "Score: " + 0;

		toGuess = 8;
		fCard = null;
		sCard = null;

		canvasDim = new Vector2 (gameObject.GetComponent<RectTransform> ().rect.width, gameObject.GetComponent<RectTransform> ().rect.height);
		minDim = (int)Mathf.Min (canvasDim.x, canvasDim.y);
		Vector2 cardDim = new Vector2 (minDim * CARD_RATE, minDim * CARD_RATE);

		int[] cardIds = { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };

		for(int i=0;i<50;i++) {
			int i1 = Random.Range (0, cardIds.Length - 1);
			int i2 = Random.Range (0, cardIds.Length - 1);
			int temp = cardIds [i1];
			cardIds [i1] = cardIds [i2];
			cardIds [i2] = temp;
		}

		cards = new GameObject[16];
		for (int x = 0; x < 4; x++) {
			for (int y = 0; y < 4; y++) {
				GameObject card= Instantiate(cardPF);
				card.GetComponent<CardScript> ().Id = cardIds [x * 4 + y];
				card.transform.SetParent (gameObject.transform);
				card.GetComponent<RectTransform> ().sizeDelta = cardDim;
				card.transform.position = getCardPos (x, y);
				cards [x * 4 + y] = card;

			}
		}
	}

	public bool canClick()
	{
		return sCard==null;
	}

	public void clicked( CardScript card)
	{
		if (fCard == null) {
			fCard = card;
		} else {
			sCard = card;
			StartCoroutine (delayMatch ());
		}
	}

	private Vector2 getCardPos(int x, int y)
	{
		float xOffset=(canvasDim.x-minDim*(CARD_RATE*4 + MARGIN_RATE*3))*0.5f;
		float yOffset=(canvasDim.y-minDim*(CARD_RATE*4 + MARGIN_RATE*3))*0.5f;
		float xPos = minDim * (CARD_RATE + MARGIN_RATE) * x+xOffset;
		float yPos = minDim * (CARD_RATE + MARGIN_RATE) * y+yOffset;
		return new Vector2 (xPos,yPos);
	}

	private void match ()
	{
		if (fCard.Id == sCard.Id) {
			fCard.freeze ();
			sCard.freeze ();
			success ();
		} else {
			fCard.Hidden = true;
			sCard.Hidden = true;
			fail ();
		}
		fCard = sCard = null;

	}

	private IEnumerator delayMatch(){
		yield return new WaitForSeconds (HIDE_DELAY);
		match ();
	}

	public void matchNow ()
	{
		Debug.Log ("Clicked");
		if (!canClick ()) {
			StopCoroutine (delayMatch());
			match ();
		}
	}

	private void success(){
		score += toGuess*10;
		scoreText.text = "Score: " + score;
		toGuess--;
		if (toGuess == 0) {
			restart.SetActive (true);
		}
	}

	private void fail(){
		score -= (8-toGuess+1)*5;
		scoreText.text = "Score: " + score;
	}
}
