using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour {

    public float firerate=1f;
    public float speed = 5f;
    public GameObject laser;
    public AudioClip sfx;
    // Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        float prob = Time.deltaTime * firerate;
        if (Random.value < prob)
            Shootback();
	}

    void Shootback()
    {
        Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1);
        GameObject laserhurt=Instantiate(laser, pos, Quaternion.identity) as GameObject;
        laserhurt.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-speed);
        AudioSource.PlayClipAtPoint(sfx,transform.position);
    }
}
