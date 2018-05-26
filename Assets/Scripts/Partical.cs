using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partical : MonoBehaviour {
	private int lane;
	private Vector3 endpoint;
	// Use this for initialization
	void Start () {
		if (lane == 0)
			endpoint = new Vector3 (-1.89f, -4.05f, 0);
		else
			endpoint = new Vector3 (1.81f, -4.05f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= (new Vector3 (0, 4f, 0) * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Miss
        if (collision.gameObject.tag == "KillBox") Destroy(gameObject);
    }

    public int Lane{
		set{lane = value;}
	}
	public Vector3 EndPoint{
		get{return endpoint;}
	}
}
