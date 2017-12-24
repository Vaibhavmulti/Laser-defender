using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycoll : MonoBehaviour {
    public float health=100f;
    public Spawnenemy again;
    public Score gotcha;
    public AudioClip sfx;
	// Use this for initialization
	void Start () {
        again = GameObject.FindObjectOfType<Spawnenemy>();
        gotcha = GameObject.FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Laserdamage laserdmg = collision.gameObject.GetComponent<Laserdamage>();  // Try other ways :(
        if (laserdmg)
        {
            health -= laserdmg.Getdamage();
            laserdmg.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                gotcha.Addscore(10);
                AudioSource.PlayClipAtPoint(sfx, transform.position);
            }
        }
    }
}
