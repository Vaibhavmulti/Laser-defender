﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyposition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position,0.5f);
    }
}
