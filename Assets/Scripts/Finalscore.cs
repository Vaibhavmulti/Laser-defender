using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finalscore : MonoBehaviour {
    public Score marks;
    public Text text; 
	// Use this for initialization
	void Start () {
        marks = GameObject.FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = Score.temp.ToString();
	}
}
