using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class Beat
{
    public float[] time;
    public string[] which;
}

[Serializable]
public class Song
{
    public Beat[] particles;
}

public class jsonParse : MonoBehaviour {

    public Song Parse(string filepath)
    {
        string stringified = "";
        try
        {
            StreamReader sr = new StreamReader(filepath);
            stringified = sr.ReadToEnd();
        }
        catch
        {
            Debug.Log(filepath + " could not be read");
        }
        Song song = JsonUtility.FromJson<Song>(stringified);
        return song;
    } 
}