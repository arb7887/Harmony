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
		track1.GetComponent<Button>().onClick.AddListener (GoToTrackOne);
		track2.GetComponent<Button> ().onClick.AddListener (GoToTrackTwo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToTrackOne(){
		SceneManager.LoadScene ("Game Scene");
	}
	public void GoToTrackTwo(){
		SceneManager.LoadScene ("Game Scene 2");
	}
}
