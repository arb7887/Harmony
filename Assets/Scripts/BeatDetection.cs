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

	public AudioSource perfect;
	public AudioSource great;
	public AudioSource good;
	public AudioSource bad;

    public void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
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
						perfect.enabled = true;
						perfect.Play();
                    }
                    //Good
					if (Mathf.Abs(distance.magnitude-radius) > 1.4f && (distance.magnitude - radius) < 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Good (lane);
						great.enabled = true;
						great.Play();
                    }
                    //Okay
					if(Mathf.Abs(distance.magnitude-radius) > 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Okay (lane);
						good.enabled = true;
						good.Play();
                    }
                }
                //Wrong
                else
                {
					gameManager.GetComponent<GameManager> ().Wrong (lane);
					bad.enabled = true;
					bad.Play();
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
