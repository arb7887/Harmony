using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //major = black orb
    //minor = white orb
    private Vector2 majorPos;
    private Vector2 minorPos;

    public GameObject major;
    public GameObject minor;

    public GameObject gameManager;

    public float bottomLineY;
    public float startX;

	void Start () {
        majorPos = major.transform.position;
        minorPos = minor.transform.position;

        majorPos.x = startX;
        minorPos.x = -startX;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) Swap();
	}

    void Swap()
    {

    }
}
