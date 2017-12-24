using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserdamage : MonoBehaviour {
    public float damage=50f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float Getdamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
