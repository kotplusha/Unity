using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private int touchCount;
	private bool toSwitch;

	private Vector3 d = new Vector3 (1, 1.1f,0);

	// Use this for initialization
	void Start () {
		toSwitch = false;
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && isGrounded())
			toSwitch = true;
	}

	void FixedUpdate(){

		if (toSwitch) {
			gSwitch ();
			toSwitch = false;
		}
	}

	bool isGrounded(){
		return Physics2D.OverlapArea(transform.position+d,transform.position-d,1<<LayerMask.NameToLayer("Wall"));
	}

	void gSwitch (){
		rigidBody.gravityScale *= -1;
		Vector2 scale= transform.localScale;
		scale.y *= -1;
		transform.localScale = scale;
	}
	void OnDestroy(){
		SceneManager.LoadScene ("Test");
	}
}
