using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    //major = black orb
    //minor = white orb
    private Vector2 majorPos;
    private Vector2 minorPos;
    public GameObject major;
    public GameObject minor;

    public float bottomLineY;
    public float startX;

    private float swapDuration = 0.1f;
    private float swapTime = 0.0f;
    private float swapPercent = 0.0f;
    private bool isSwapping = false;
    private Vector2 oldMajorPos;
    private Vector2 oldMinorPos;

    public GameObject gameManager;

    //end game variables
    private float mergeDuration = 1.0f;
    private float mergeTime = 0.0f;
    private float mergePercent = 0.0f;
    private float ascendDuration = 1.0f;
    private float ascendTime = 0.0f;
    private float ascendPercent = 0.0f;
    public GameObject endCanvas;

    void Start () {
        majorPos = major.transform.position;
        minorPos = minor.transform.position;

        majorPos.x = startX;
        minorPos.x = -startX;
        majorPos.y = bottomLineY;
        minorPos.y = bottomLineY;
	}
	
	void Update () {
        majorPos = major.transform.position;
        minorPos = minor.transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && !isSwapping) Swap();
        if (isSwapping)
        {
            swapTime += Time.deltaTime;
            swapPercent = swapTime / swapDuration;
            majorPos = Vector2.Lerp(oldMajorPos, oldMinorPos, swapPercent);
            minorPos = Vector2.Lerp(oldMinorPos, oldMajorPos, swapPercent);
            if (swapTime >= swapDuration)
            {
                isSwapping = false;
                swapPercent = 0.0f;
                swapTime = 0.0f;
                major.GetComponent<BeatDetection>().lane = Mathf.Abs(major.GetComponent<BeatDetection>().lane - 1);
                minor.GetComponent<BeatDetection>().lane = Mathf.Abs(minor.GetComponent<BeatDetection>().lane - 1);
            }
        }
        if (gameManager.GetComponent<GameManager>().endGameSequence)
        {
            if (mergeTime < mergeDuration)
            {
                mergeTime += Time.deltaTime;
                mergePercent = mergeTime / mergeDuration;
                majorPos = Vector2.Lerp(oldMajorPos, new Vector2(0.0f, oldMajorPos.y), mergePercent);
                minorPos = Vector2.Lerp(oldMinorPos, new Vector2(0.0f, oldMinorPos.y), mergePercent);
            }
            else 
            {
                ascendTime += Time.deltaTime;
                ascendPercent = ascendTime / ascendDuration;
                majorPos = Vector2.Lerp(new Vector2(0.0f, 4.0f), new Vector2(0.0f, -4.0f), ascendPercent);
                majorPos = Vector2.Lerp(new Vector2(0.0f, 4.0f), new Vector2(0.0f, -4.0f), ascendPercent);
                if(ascendTime >= ascendPercent)
                {
                    endCanvas.SetActive(true);
                    gameManager.GetComponent<GameManager>().endGameSequence = false;
                }
            }
        }
        major.transform.position = majorPos;
        minor.transform.position = minorPos;
	}

    void Swap()
    {
        isSwapping = true;
        oldMajorPos = majorPos;
        oldMinorPos = minorPos;
    }

    public void End()
    {
        oldMajorPos = majorPos;
        oldMinorPos = minorPos;
    }
}
