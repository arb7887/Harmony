using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //important game info
	//end game information
	private int score = 0;
	private int numMissed = 0;
	private int numWrong = 0;
	private int numPerfect = 0;
	private int numGood = 0;
	private int numOkay = 0;
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

	public Sprite[] results;
	public Image holderL;
	public Image holderR;
	public Canvas can;
	private Image myHolderL;
	private Image myHolderR;
	private float rightTime;
	private float leftTime;
    public bool endGameSequence;
    private bool canSpawn;

    //song file fields
    public GameObject json;
    private Song songOBJ;
    private int noteIndex;
	public string fileLoc;
	// Use this for initialization
	void Start () {
		songOBJ = json.GetComponent<jsonParse>().Parse(fileLoc);
		//song.Play ();
		p = new List<GameObject> ();
        //InvokeRepeating("Spawn",3f,1f);
        noteIndex = 0;
		time = 0.0f;
        endGameSequence = false;
        canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
		//check to make sure the song is still playing, when song is done game is done
		shownScore.text = "Score: " + score;
		time += Time.deltaTime*1000;
		if (myHolderL != null) {
			leftTime += Time.deltaTime;
			if (leftTime >= 2f) {
				Destroy (myHolderL);
				leftTime = 0;
			}
		}
		if (myHolderL != null) {
			rightTime += Time.deltaTime;
			if (rightTime >= 2f) {
				Destroy (myHolderR);
				rightTime = 0;
			}
		}
		//Debug.Log (time);
        //if(time > 5000f && time < 5050f)  InvokeRepeating("Spawn",8f,1f);
        if(time + 2000 >= songOBJ.particles[noteIndex].time[0] && canSpawn)
        {
            string which = songOBJ.particles[noteIndex].which[0];
            string left = which.Substring(0, 1);
            string right = which.Substring(1, 1);
            if (left != "x") Spawn(left, 0);
            if (right != "x") Spawn(right, 1);
            if (songOBJ.particles.Length > noteIndex) noteIndex++;
            else
            {
                endGameSequence = true;
                GetComponent<PlayerControls>().End();
                canSpawn = false;
            }
        }
	}

	void Spawn(string c, int l){
		int color = c == "b" ? 0 : 1;

		int lane = l;
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

	public void Perfect(int lane){
		score += perfect;
		if (lane == 0 && myHolderL == null) {
			myHolderL = Instantiate (holderL, can.transform);
		} else if (lane == 1 && myHolderR == null) {
			myHolderR = Instantiate (holderR, can.transform);
		}
		//set the image

		switch (lane) {
		case 0:
			myHolderL.GetComponent<Image> ().sprite = results [0];
			break;
		case 1:
			myHolderR.GetComponent<Image> ().sprite = results [0];
				break;
		}
		numPerfect++;
	}

	public void Good(int lane){
		score += good;
		if (lane == 0 && myHolderL==null) {
			myHolderL = Instantiate (holderL, can.transform);
		}
		else if(lane == 1 && myHolderR==null)myHolderR = Instantiate (holderR, can.transform);

		switch (lane) {
		case 0:
			myHolderL.GetComponent<Image> ().sprite = results [1];
			break;
		case 1:
			myHolderR.GetComponent<Image> ().sprite = results [1];
			break;
		}
		numGood++;
	}

	public void Okay(int lane){
		score += okay;
		if (lane == 0 && myHolderL==null) {
			myHolderL = Instantiate (holderL, can.transform);
		}
		else if(lane == 1 && myHolderR==null)myHolderR = Instantiate (holderR, can.transform);
		switch (lane) {
		case 0:
			myHolderL.GetComponent<Image> ().sprite = results [2];
			break;
		case 1:
			myHolderR.GetComponent<Image> ().sprite = results [2];
				break;
		}
		numOkay++;
	}

	public void Wrong(int lane){
		score += wrong;
		if (lane == 0 && myHolderL==null) {
			myHolderL = Instantiate (holderL, can.transform);
		}
		else if(lane == 1 && myHolderR==null)myHolderR = Instantiate (holderR, can.transform);
		switch (lane) {
		case 0:
			myHolderL.GetComponent<Image> ().sprite = results [3];
			break;
		case 1:
			myHolderR.GetComponent<Image> ().sprite = results [3];
				break;
		}
		numWrong++;
	}
	public void Miss(int lane){
		score += miss;
		if (lane == 0 && myHolderL==null) {
			myHolderL = Instantiate (holderL, can.transform);
		}
		else if(lane == 1 && myHolderR==null)myHolderR = Instantiate (holderR, can.transform);

		switch (lane) {
		case 0:
			myHolderL.GetComponent<Image> ().sprite = results [4];
			break;
		case 1:
			myHolderR.GetComponent<Image> ().sprite = results [4];
				break;
		}
		numMissed++;
	}
	//get set
}
