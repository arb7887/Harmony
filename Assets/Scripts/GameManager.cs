using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

//important game info
	//end game information
	private int score = 0;
	private int numMised = 0;
	private int numHit = 0;
	//scoring stuff
	private int perfect = 10;
	private int good = 5;
	private int okay = 2;
	private int wrong = -5;
	private int miss = -10;

	private bool pause;
	public AudioSource song;

	public Text shownScore;
	public GameObject major;
	public GameObject minior;

	private float time;
	private List<GameObject> particles;

	// Use this for initialization
	void Start () {
		song.Play ();
		particles = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		//check to make sure the song is still playing, when song is done game is done
		shownScore = score.ToString();
		time += Time.deltaTime*1000;
		if (time > 3000f && song.isPlaying) {
			//buffer for spawning things
			//check fo the current time and if its something that should happen, let it happen
			//spawn particle at there spawn - time to travel to the bar
			foreach(GameObject p in particles){
				
			}
		}
		else {
			//end game stuff
		}
	}

	void SpawnParticle(int color, int lane){
		switch (lane) {
		case 0:
			if (color == 0)
				particles.Add (Instantiate (major, new Vector3 (2, 4, 0), new Quaternion (0, 0, 0, 0)));
			else (color == 1)
				particles.Add(Instantiate(minior, new Vector3(-2,4,0), new Quaternion(0,0,0,0)));
		}
	}

	//get set
}
