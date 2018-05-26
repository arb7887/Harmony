using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public GameObject track1;
	public GameObject track2;

	// Use this for initialization
	void Start () {
		track1.GetComponent<Button>().onClick.AddListener (GoToGame);
		track2.GetComponent<Button> ().onClick.AddListener (GoToGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToGame(){
		SceneManager.LoadScene ("Game Scene");
	}
}
