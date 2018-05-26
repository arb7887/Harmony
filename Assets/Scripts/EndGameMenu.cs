using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour {
	public GameObject button;
	// Use this for initialization
	void Start () {
		button.GetComponent<Button>().onClick.AddListener (GoHome);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoHome(){
		SceneManager.LoadScene ("Main");
	}
}
