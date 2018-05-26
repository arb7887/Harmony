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
                if (otherTag == gameObject.tag)
                {
                    Vector2 distance = other.transform.position - gameObject.transform.position;
					Debug.Log (Mathf.Abs(distance.magnitude-radius));
                    //Perfect
					if(Mathf.Abs(distance.magnitude-radius) < 1.4f)
                    {
						gameManager.GetComponent<GameManager> ().Perfect (lane);
                    }
                    //Good
					if (Mathf.Abs(distance.magnitude-radius) > 1.4f && (distance.magnitude - radius) < 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Good (lane);
                    }
                    //Okay
					if(Mathf.Abs(distance.magnitude-radius) > 1.6f)
                    {
						gameManager.GetComponent<GameManager> ().Okay (lane);
                    }
                }
                //Wrong
                else
                {
					gameManager.GetComponent<GameManager> ().Wrong (lane);
                }
                Destroy(other);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Minor particle")
            otherTag = "Minor";
        else if (collision.gameObject.tag == "Major particle")
            otherTag = "Major";
        other = collision.gameObject;
        isColliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
