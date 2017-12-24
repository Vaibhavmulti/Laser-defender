using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackposition : MonoBehaviour {
    MovePlayer player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<MovePlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(player.transform.position.x, transform.position.y);
        transform.position = pos;
	}
}
