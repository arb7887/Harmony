using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetection : MonoBehaviour {
    public GameObject gameManager;
    public bool isColliding = false;
    private string otherTag = "";
    private GameObject other;
    public int lane;
    private float radius;
	private AudioSource myAudio;

	public AudioClip perfect;
	public AudioClip great;
	public AudioClip good;
	public AudioClip bad;

    public void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
		myAudio = GetComponent<AudioSource> ();
        if (tag == "Major") lane = 1;
        else lane = 0;
    }
    public void Update()
    {
        if (isColliding)
        {
            if ((lane == 1 && Input.GetKeyDown(KeyCode.RightArrow))
                || (lane == 0 && Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                //Correct
                Debug.Log(otherTag);
                Debug.Log(tag);
                if (otherTag == (tag + " particle"))
                {
                    Vector2 distance = other.transform.position - gameObject.transform.position;
						
                    //Perfect
					if(Mathf.Abs(distance.magnitude-radius) < 1.4f)
                    {
						gameManager.GetComponent<GameManager> ().Perfect (lane);
						myAudio.clip = perfect;
						myAudio.Play ();
                    }
                    //Good
					if (Mathf.Abs(distance.magnitude-radius) > 1.4f && (distance.magnitude - radius) < 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Good (lane);
						myAudio.clip = great;
						myAudio.Play ();
                    }
                    //Okay
					if(Mathf.Abs(distance.magnitude-radius) > 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Okay (lane);
						myAudio.clip = good;
						myAudio.Play ();
                    }
                }
                //Wrong
                else
                {
					gameManager.GetComponent<GameManager> ().Wrong (lane);
					myAudio.clip = bad;
					myAudio.Play ();
                }
                Destroy(other);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Major particle" || collision.gameObject.tag == "Minor particle")
        {
            otherTag = collision.gameObject.tag;
            other = collision.gameObject;
            isColliding = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
