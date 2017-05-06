using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour {

	public GameObject playerFrame;
	public GameObject wallBlock;
	public GameObject trapBlock;
	private Vector2 frame;

	private int last;
	private bool isRunning;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		
		if (isRunning) {
			while((playerFrame.transform.position.x + frame.x / 2) > last){
				last++;
				/*
				Instantiate (wallBlock, new Vector3 (last, frame.y / 2, 0), Quaternion.identity);
				Instantiate (wallBlock, new Vector3 (last, -frame.y / 2, 0), Quaternion.identity);
				if (Random.Range (0, 4) == 0)
					Instantiate (wallBlock, new Vector3 (last, frame.y / 2-1, 0), Quaternion.identity);
				if (Random.Range (0, 4) == 0)
					Instantiate (wallBlock, new Vector3 (last, -frame.y / 2+1, 0), Quaternion.identity);
				*/
				/*
				for(int i=(int)-frame.y/2;i<=frame.y/2;i++)
					if(Random.Range(0,(int)(frame.y/2-Mathf.Abs(i))+1)==0)
						Instantiate (wallBlock, new Vector3 (last, i, 0), Quaternion.identity);
				*/
				Instantiate (wallBlock, new Vector3 (last, frame.y/2, 0), Quaternion.identity);
				Instantiate (wallBlock, new Vector3 (last, -frame.y/2, 0), Quaternion.identity);
				if(Random.Range(0,3)==0)
					Instantiate (wallBlock, new Vector3 (last, frame.y/2-1, 0), Quaternion.identity);
				if(Random.Range(0,3)==0)
					Instantiate (wallBlock, new Vector3 (last, -frame.y/2+1, 0), Quaternion.identity);

			}
		}
	}

	public void StartGenerator(Vector2 frame){
		if (!isRunning) {
			isRunning = true;
			this.frame = frame;
			for (int i = (int)-frame.x/2; i <= frame.x/2; i++) {
				Instantiate (wallBlock, new Vector3 (i, frame.y / 2, 0), Quaternion.identity);
				Instantiate (wallBlock, new Vector3 (i, -frame.y / 2, 0), Quaternion.identity);
			}
			last = (int)frame.x / 2;
		}

	}
}
