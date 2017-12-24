using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour {
    public GameObject enemyspawn;
    public float width, height, speed;
    public bool check = true;
    Vector3 left, right;
    int dirr;
    float xmin,xmax,min, max;
	// Use this for initialization
	void Start () {
        width = 10f;
        height = 10f;
        xmin = xmax = 0;
        dirr = 1;
        Spawn();
        float dis = transform.position.z - Camera.main.transform.position.z;
        left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dis));  
        right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dis));
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
    }
    // Update is called once per frame
    void Update () {
        if(check)
        {
            foreach(Transform child in transform)
            {
                if (child.transform.position.x < xmin)
                    xmin = child.transform.position.x;
                if (child.transform.position.x > xmax)
                    xmax = child.transform.position.x;
            }
            print(xmin);
            print(xmax);
            check = false;
            min = left.x - xmin;
            max = right.x - xmax;
            print(min);
            print(max);
        }
        if (Alldead())
            Spawn();
        if(dirr==0)
        {
            if (transform.position.x >= min)
                transform.position += Vector3.left * speed * Time.deltaTime;
            else
                dirr = 1;
        }
        if (dirr == 1)
        {
            if (transform.position.x <= max)
                transform.position += Vector3.right * speed * Time.deltaTime;
            else
                dirr = 0;
        }

    }
    void Spawn()
    {
        Transform freeposition = Nextfreeposition();
        if(freeposition)
        {
            GameObject enemy = Instantiate(enemyspawn, freeposition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freeposition;
        }
        if (Nextfreeposition())
        {
            Invoke("Spawn", 0.5f);
        }
    }
    Transform Nextfreeposition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
                return child;
        }
        return null;
    }
    bool Alldead()
    {
        foreach (Transform trans in transform)
        {
            if (trans.childCount > 0)
                return false;
        }
        return true;
    }
}
