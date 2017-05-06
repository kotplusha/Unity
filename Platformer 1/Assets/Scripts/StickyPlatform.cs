using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.transform.parent = gameObject.transform;
		}
	}

	public void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			col.gameObject.transform.parent = null;
		}
	}
}
