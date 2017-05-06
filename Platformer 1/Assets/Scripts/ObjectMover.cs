using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {
	
	public Vector2 direction;
	public float amplitude;
	public float cycleLength;

	private Vector2 anchor;
	private float phase;

	// Use this for initialization
	void Start () {
		direction = direction.normalized;
		anchor = gameObject.transform.position;
		phase = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		phase += (Time.fixedDeltaTime/cycleLength)*Mathf.PI*2;
		phase = (phase > Mathf.PI * 2) ? phase - Mathf.PI * 2 : phase;
		gameObject.transform.position = anchor + direction * Mathf.Sin (phase) * amplitude;


	}
}
