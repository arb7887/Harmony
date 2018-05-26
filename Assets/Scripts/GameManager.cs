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

	public Image[] results;
	public Image holder;
	public Canvas can;
	private Image myHolder;
	private float resultsLength;

	// Use this for initialization
	void Start () {
		//song.Play ();
		p = new List<GameObject> ();
		InvokeRepeating("Spawn",3f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		//check to make sure the song is still playing, when song is done game is done
		shownScore.text = "Score: " + score;
		time += Time.deltaTime*1000;
		if (myHolder != null) {
			resultsLength += Time.deltaTime;
		}
		if (time > 1000f && time < 2000f) {
			//buffer for spawning things
			//check fo the current time and if its something that should happen, let it happen
			//spawn particle at there spawn - time to travel to the bar
			//InvokeRepeating("Spawn",3f,1f);
		}
		else {
			//end game stuff
		}

	}

	void Spawn(){
		int color = Random.Range (0, 2);

		int lane = Random.Range (0, 2);
		Debug.Log (color + " " + lane);
		switch (lane) {
		case 0:
			if (color == 0) {
				p.Add (Instantiate (majorP, new Vector3 (-2, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 0;
			} else if (color == 1) {
				p.Add (Instantiate (miniorP, new Vector3 (-2, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 0;
			}
			break;
		case 1:
			if (color == 0) {
				p.Add (Instantiate (majorP, new Vector3 (2, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 1;
			} else if (color == 1) {
				p.Add (Instantiate (miniorP, new Vector3 (2, 4, 0), new Quaternion (0, 0, 0, 0)));
				p [p.Count - 1].GetComponent<Partical> ().Lane = 1;
			}
			break;
		}
	}

	public void Perfect(){
		score += perfect;
		if (myHolder == null)
			myHolder = Instantiate (holder, can.transform);
	}

	public void Good(){
		score += good;
		if(myHolder == null)myHolder = Instantiate (holder, can.transform);
	}

	public void Okay(){
		score += okay;
		if(myHolder == null)myHolder = Instantiate (holder, can.transform);
	}

	public void Wrong(){
		score += wrong;
		if(myHolder == null)myHolder = Instantiate (holder, can.transform);
	}
	public void Miss(){
		score += miss;
		if(myHolder == null)myHolder = Instantiate (holder, can.transform);
	}
	//get set
}
