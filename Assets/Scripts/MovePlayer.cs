using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public float speed = 20f;
    public float projectilespeed = 5f;
    public float firerate = 0.3f;
    float min, max;
    float pos;
    float padding = .7f;
    public GameObject laser,tip;
    public float health=300f;
    public Trackposition stoptrack;
    public AudioClip sfx;
    public LevelManager lv;
    private Health healthmanager;
	// Use this for initialization
	void Start () {
        float dis = transform.position.z - Camera.main.transform.position.z;
        Vector3 left= Camera.main.ViewportToWorldPoint(new Vector3(0,0,dis));  // 0 0 means the cursor is at the bottom left
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dis)); // 1 0 means the cursor is at bottom right 
        // 0.5 0.5 means the cursor is at the centre
        stoptrack = GameObject.FindObjectOfType<Trackposition>();
        min = left.x+padding;
        max = right.x-padding;
        healthmanager = GameObject.FindObjectOfType<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += (new Vector3(Input.acceleration.x * speed * Time.deltaTime,0,0));
        pos = Mathf.Clamp(transform.position.x, min, max);
        transform.position = new Vector3(pos, transform.position.y, 0f);
    }
    public void shootdown()
    {
        InvokeRepeating("shoot", 0.00001f, firerate);
    }

    public void cancelshoot()
    {
        CancelInvoke("shoot");
    }

    void shoot()
    {
        GameObject lasershoot = Instantiate(laser, tip.transform.position, Quaternion.identity) as GameObject;
        lasershoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectilespeed);
        AudioSource.PlayClipAtPoint(sfx,transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Laserdamage laserdmg = collision.gameObject.GetComponent<Laserdamage>();  // Try other ways :(
        if (laserdmg)
        {
            health -= laserdmg.Getdamage();
            healthmanager.Takedamager((int)laserdmg.Getdamage());
            laserdmg.Hit();
            if (health <= 0)
            {
                stoptrack.enabled = false;
                Destroy(gameObject);
                lv.LoadLevel("Win Screen");
            }
        }
    }
}
