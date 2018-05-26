using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partical : MonoBehaviour {
	private Vector2 oldPos;
	private Vector2 curPos;
	private float fallTime;
	private float fallLength;
	private float fallPrecent;
	private bool isFalling;
	private Vector3 endPoint;
	private int lane;
	// Use this for initialization
	void Start () {
		isFalling = true;
		oldPos = transform.position;
		fallLength = .5f;
		if (lane == 0)
			endPoint = new Vector3 (-1.89f, -4.05f, 0);
		else
			endPoint = new Vector3 (1.81f, -4.05f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isFalling) {
			curPos = transform.position;
			if (isFalling)
			{
				fallTime += Time.deltaTime;
				fallPrecent = fallTime / fallLength;
				curPos = Vector2.Lerp (oldPos, endPoint, fallPrecent);
				if (transform.position == endPoint)
				{
					fallPrecent = 0.0f;
					fallTime = 0.0f;
					isFalling = false;
				}
			}
			transform.position = curPos;
		}
	}

	public int Lane{
		set{lane = value;}
	}
	public Vector3 EndPoint{
		get{return endPoint;}
	}
	public bool IsFalling{
		get{return isFalling;}
	}
}
