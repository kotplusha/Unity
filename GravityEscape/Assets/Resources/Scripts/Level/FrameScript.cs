using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameScript : MonoBehaviour {

	public float acceleration;
	public float speed;

	private Vector2 _frame;
	private BoxCollider2D frameColl;
	private LevelGeneratorScript generator;

	public GameObject lg;


	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		frame = new Vector2 (Camera.main.orthographicSize * 2f * Camera.main.aspect, Camera.main.orthographicSize * 2f);
		frameColl = gameObject.GetComponent<BoxCollider2D> ();
		frameColl.size = frame;
		generator = lg.GetComponent<LevelGeneratorScript> ();
		generator.StartGenerator (frame);
	}
	
	// Update is called once per frame
	void Update () {
		
		//speed += acceleration;
		//transform.localPosition += new Vector3 (speed, 0);
	}

	void FixedUpdate () {

		speed += acceleration;
		transform.localPosition += new Vector3 (speed, 0);
	}

	public Vector2 frame{
		get{
			return _frame;
		}
		set{
			_frame = value;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		Destroy (other.gameObject);
	}
}
