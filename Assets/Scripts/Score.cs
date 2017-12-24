using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public Text score;
    //float count=0;
    public static int temp;
	// Use this for initialization
	void Start () {
        score.text = "0";
        temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Addscore(int points)
    {
        temp += points;
        score.text=temp.ToString();
    }

    public void Resetscore()
    {
        score.text = "0";
    }
}
