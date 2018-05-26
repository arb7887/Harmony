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
	public GameObject majorP;
	public GameObject miniorP;
	public GameObject major;
	public GameObject minior;

	private float time;
	private List<GameObject> p;

	private float fallTime;
	private float fallDur;
	// Use this for initialization
	void Start () {
		//song.Play ();
		p = new List<GameObject> ();
		fallTime = 0.0f;
		fallDur = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		//check to make sure the song is still playing, when song is done game is done
		//shownScore = score.ToString();
		time += Time.deltaTime*1000;
		if (time > 3000f && time < 3100f) {
			//buffer for spawning things
			//check fo the current time and if its something that should happen, let it happen
			//spawn particle at there spawn - time to travel to the bar
			SpawnParticle(1,0);
			CheckPart ();
		}
		else {
			//end game stuff
		}
	}

	void SpawnParticle(int color, int lane){
		switch (lane) {
		case 0:
			if (color == 0) {
				p.Add (Instantiate (majorP, new Vector3 (major.transform.position.x, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 0;
			} else if (color == 1) {
				p.Add (Instantiate (miniorP, new Vector3 (minior.transform.position.x, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 0;
			}
			break;
		case 1:
			if (color == 0) {
				p.Add (Instantiate (majorP, new Vector3 (major.transform.position.x, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 1;
			} else if (color == 1) {
				p.Add (Instantiate (miniorP, new Vector3 (major.transform.position.x, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 1;
			}
			break;
		}
	}
	void CheckPart(){
		foreach (GameObject part in p) {
			if (!part.GetComponent<Partical>().IsFalling) {
				//Destroy (part);
			}
		}
	}
	//get set
}
